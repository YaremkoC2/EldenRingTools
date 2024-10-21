using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;
using System.Diagnostics;

namespace EldenRingBossChecklist
{
    public partial class BossList : Form
    {
        List<Boss> bossList;   // list to hold all the bosses
        BindingSource bsBoss;  // Binding source to assign the list to the DGV

        // Dictionary for whether a boss is checked
        Dictionary<string, bool> bossDictionary;

        public BossList()
        {
            InitializeComponent();
            bossDictionary = new Dictionary<string, bool>();
            bossList = Boss.LoadBosses();

            // Create config file if it doesn't exist
            string path = "config.ini";
            if (!File.Exists(path))
            {
                try
                {
                    // Create the file and write each boss to the config
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        foreach (Boss boss in bossList)
                        {
                            writer.WriteLine($"{boss.Location} : {false}");
                            bossDictionary[boss.Location] = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    // Read the file and populate the dictionary
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split(new[] { " : " }, StringSplitOptions.None);
                            if (parts.Length == 2)
                            {
                                string bossLocation = parts[0].Trim();
                                bool isFound = bool.Parse(parts[1].Trim());
                                bossDictionary[bossLocation] = isFound;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // load the bosses and assign data source to the DGV
            bsBoss = new BindingSource();
            bsBoss.DataSource = bossList;
            UI_DGV_bosses.DataSource = bsBoss;

            // Create a new DataGridViewCheckBoxColumn
            DataGridViewCheckBoxColumn foundColumn = new DataGridViewCheckBoxColumn();
            foundColumn.HeaderText = "Found";
            foundColumn.Name = "Found";

            // Insert the column at the first position
            UI_DGV_bosses.Columns.Insert(0, foundColumn);

            // Create a new DataGridViewLinkColumn for the second column
            DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
            linkColumn.HeaderText = UI_DGV_bosses.Columns[2].HeaderText;
            linkColumn.Name = UI_DGV_bosses.Columns[2].Name;
            linkColumn.DataPropertyName = UI_DGV_bosses.Columns[2].DataPropertyName;
            linkColumn.Width = UI_DGV_bosses.Columns[2].Width;

            // Insert the link column at the second position
            UI_DGV_bosses.Columns.Insert(2, linkColumn);

            // Remove the original text column
            UI_DGV_bosses.Columns.RemoveAt(3);

            // Style the DGV
            UI_DGV_bosses.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_bosses.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UI_DGV_bosses.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_bosses.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_bosses.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Handle the DataBindingComplete event to check the checkboxes
            UI_DGV_bosses.DataBindingComplete += UI_DGV_bosses_DataBindingComplete;

            // Handle the CellContentClick event
            UI_DGV_bosses.CellContentClick += UI_DGV_bosses_CellContentClick;

            // Handle the CellValueChanged event to update the dictionary and ini file
            UI_DGV_bosses.CellValueChanged += UI_DGV_bosses_CellValueChanged;
            UI_DGV_bosses.CurrentCellDirtyStateChanged += UI_DGV_bosses_CurrentCellDirtyStateChanged;
        }

        // Event handler for DataBindingComplete event
        private void UI_DGV_bosses_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in UI_DGV_bosses.Rows)
            {
                string bossLocation = row.Cells["Location"].Value.ToString();
                if (bossDictionary.ContainsKey(bossLocation))
                {
                    row.Cells["Found"].Value = bossDictionary[bossLocation];
                }
            }
        }

        // Event handler for CellContentClick event
        private void UI_DGV_bosses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                var cell = UI_DGV_bosses[e.ColumnIndex, e.RowIndex] as DataGridViewLinkCell;
                if (cell != null)
                {
                    string url = cell.Value.ToString();
                    Process.Start(url);
                }
            }
        }

        // Event handler for CellValueChanged event
        private void UI_DGV_bosses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                var checkBoxCell = UI_DGV_bosses[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null)
                {
                    string bossLocation = UI_DGV_bosses.Rows[e.RowIndex].Cells["Location"].Value.ToString();
                    bool isChecked = (bool)checkBoxCell.Value;
                    bossDictionary[bossLocation] = isChecked;
                    WriteConfigFile();
                }
            }
        }

        // Event handler for CurrentCellDirtyStateChanged event
        private void UI_DGV_bosses_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (UI_DGV_bosses.IsCurrentCellDirty)
            {
                UI_DGV_bosses.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Method to write the dictionary to the config file
        private void WriteConfigFile()
        {
            string path = "config.ini";
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (var entry in bossDictionary)
                    {
                        writer.WriteLine($"{entry.Key} : {entry.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Hide all rows that have been checked if this is checked, otherwise
        // unhide them
        private void UI_cbox_Hide_CheckedChanged(object sender, EventArgs e)
        {
            if (UI_cbox_Hide.Checked)
            {
                List<Boss> temp = new List<Boss>(bossList);

                foreach (var boss in bossDictionary)
                {
                    if (boss.Value == true)
                    {
                        temp.RemoveAll((x) => x.Location == boss.Key);
                    }
                }

                bsBoss.DataSource = temp;
                UI_DGV_bosses.DataSource = bsBoss;
                return;
            }

            bsBoss.DataSource = bossList;
            UI_DGV_bosses.DataSource = bsBoss;
        }
    }
}
