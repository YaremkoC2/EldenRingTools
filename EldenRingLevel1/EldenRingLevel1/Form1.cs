///////////////////////////////////////////////////////////////////////////////////////////////////
///  Project: Elden Ring Level 1 Gear Finder
///  Created: Mar. 8, 2024
///  Author: Cole Yaremko - CYaremko on github
/// 
///  This project is a forms app that will pull weapon data from the elden ring wiki and determine
///  which weapons can be used by a level 1 character based on stat boosting gear. 
///  
///  Modification History: See Git
///  Program status: Created
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace EldenRingLevel1
{
    public partial class GearCalc : Form
    {
        #region Members
        // Tuple that will hold the players data
        (int Vig, int Mind, int End, int Str, int Dex, int Int, int Fai, int Arc) player = (10, 10, 10, 10, 10, 10, 10, 10);

        // lists to hold weapons and spells
        List<Weapon> weapons = new List<Weapon>();
        List<Spell> spells = new List<Spell>();

        // URLs for all the weapon types
        string[] weaponUrls = {
            "https://eldenring.wiki.fextralife.com/Daggers", "https://eldenring.wiki.fextralife.com/Straight+Swords",
            "https://eldenring.wiki.fextralife.com/Greatswords", "https://eldenring.wiki.fextralife.com/Colossal+Swords",
            "https://eldenring.wiki.fextralife.com/Thrusting+Swords", "https://eldenring.wiki.fextralife.com/Heavy+Thrusting+Swords",
            "https://eldenring.wiki.fextralife.com/Curved+Swords", "https://eldenring.wiki.fextralife.com/Curved+Swords",
            "https://eldenring.wiki.fextralife.com/Curved+Greatswords", "https://eldenring.wiki.fextralife.com/Katanas",
            "https://eldenring.wiki.fextralife.com/Twinblades", "https://eldenring.wiki.fextralife.com/Axes",
            "https://eldenring.wiki.fextralife.com/Flails", "https://eldenring.wiki.fextralife.com/Great+Spears",
            "https://eldenring.wiki.fextralife.com/Reapers", "https://eldenring.wiki.fextralife.com/Torches",
            "https://eldenring.wiki.fextralife.com/Whips", "https://eldenring.wiki.fextralife.com/Claws",
            "https://eldenring.wiki.fextralife.com/Ballistas" };

        // Bad weapon URLS
        string[] badWeaponUrls = {
           "https://eldenring.wiki.fextralife.com/Greataxes", "https://eldenring.wiki.fextralife.com/Hammers",
           "https://eldenring.wiki.fextralife.com/Great+Hammers", "https://eldenring.wiki.fextralife.com/Colossal+Weapons",
           "https://eldenring.wiki.fextralife.com/Spears", "https://eldenring.wiki.fextralife.com/Light+Bows",
           "https://eldenring.wiki.fextralife.com/Greatbows", "https://eldenring.wiki.fextralife.com/Glintstone+Staffs",
           "https://eldenring.wiki.fextralife.com/Halberds"
        };

        // Even worse somehow??
        string sealsUrl = "https://eldenring.wiki.fextralife.com/Sacred+Seals";
        string fistUrl = "https://eldenring.wiki.fextralife.com/Fists";
        string bowUrl = "https://eldenring.wiki.fextralife.com/Bows";
        string xbowUrl = "https://eldenring.wiki.fextralife.com/Crossbows";

        // URLs for the spell types
        string[] spellUrls = {"https://eldenring.wiki.fextralife.com/Sorceries", "https://eldenring.wiki.fextralife.com/Incantations"};

        // Binding Sources
        BindingSource bsWeapon = new BindingSource();
        BindingSource bsSpell = new BindingSource();

        // Create a Dictionary for the Helmets and talismans
        Dictionary<string, (int Vig, int Mind, int End, int Str, int Dex, int Int, int Fai, int Arc)> helmets 
            = new Dictionary<string, (int Vig, int Mind, int End, int Str, int Dex, int Int, int Fai, int Arc)>();
        Dictionary<string, (int Vig, int Mind, int End, int Str, int Dex, int Int, int Fai, int Arc)> talismans
            = new Dictionary<string, (int Vig, int Mind, int End, int Str, int Dex, int Int, int Fai, int Arc)>();

        // checkboxes to only allow two checkboxes to be checked 
        CheckBox[] checkedBoxes = new CheckBox[2];
        #endregion

        public GearCalc()
        {
            InitializeComponent();

            #region Load Weapons
            // Add the binding source to the DGV
            UI_DGV_Weapons.DataSource = bsWeapon;

            // Load all the weapons from each of the urls
            foreach (string url in weaponUrls)
            {
                weapons.AddRange(Weapon.LoadWeapons(url, 0));
            }
            foreach (string url in badWeaponUrls)
            {
                weapons.AddRange(Weapon.LoadWeapons(url, 1));
            }
            weapons.AddRange(Weapon.LoadWeapons(sealsUrl, 2));
            weapons.AddRange(Weapon.LoadFists(fistUrl));
            weapons.AddRange(Weapon.LoadBows(bowUrl));
            weapons.AddRange(Weapon.LoadXBows(xbowUrl));

            // show weapons that match the players stats
            MatchWeapons();
            #endregion

            #region Load Spells
            // Add the binding source to the DGV
            UI_DGV_Spells.DataSource = bsSpell;

            // load all the spells from each url
            foreach(string url in spellUrls)
            {
                spells.AddRange(Spell.LoadSpells(url));
            }

            // show spells that match the players stats
            MatchSpells();
            #endregion

            #region labels on the table
            UI_table_Stats.Controls.Add(new Label { Text = "Vigor", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "Vig" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.Vig}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "VigVal" });
            UI_table_Stats.Controls.Add(new Label { Text = "Mind", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "Mind" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.Mind}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "MindVal" });
            UI_table_Stats.Controls.Add(new Label { Text = "Endurance", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "End" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.End}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "EndVal" });
            UI_table_Stats.Controls.Add(new Label { Text = "Strength", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "Str" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.Str}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "StrVal" });
            UI_table_Stats.Controls.Add(new Label { Text = "Dexterity", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "Dex" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.Dex}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "DexVal" });
            UI_table_Stats.Controls.Add(new Label { Text = "Intelligence", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "Int" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.Int}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "IntVal" });
            UI_table_Stats.Controls.Add(new Label { Text = "Faith", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "Fai" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.Fai}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "FaiVal" });
            UI_table_Stats.Controls.Add(new Label { Text = "Arcane", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "Arc" });
            UI_table_Stats.Controls.Add(new Label { Text = $"{player.Arc}", Anchor = AnchorStyles.Left, AutoSize = true, Tag = "ArcVal" });
            #endregion

            #region Add Helmets 
            // Manually adding helmets to the Dictionary
            helmets.Add("None", (0, 0, 0, 0, 0, 0, 0, 0));
            helmets.Add("Hierodas Glintstone Crown (Int +2, End +2)", (0, 0, 2, 0, 0, 2, 0, 0));
            helmets.Add("Lazuli Glintstone Crown (Int +3, Dex +3)", (0, 0, 0, 0, 3, 3, 0, 0));
            helmets.Add("Karolos Glintstone Crown (Int +3)", (0, 0, 0, 0, 0, 3, 0, 0));
            helmets.Add("Olivinus Glintstone Crown (Int +3)", (0, 0, 0, 0, 0, 3, 0, 0));
            helmets.Add("Twinsage Glintstone Crown (Int +6)", (0, 0, 0, 0, 0, 6, 0, 0));
            helmets.Add("Haima Glintstone Crown (Int +2, Str +2)", (0, 0, 0, 2, 0, 2, 0, 0));
            helmets.Add("Witch's Glintstone Crown (Int +3, Arc +3)", (0, 0, 0, 0, 0, 3, 0, 3));
            helmets.Add("Crimson Hood (Vig +1)", (1, 0, 0, 0, 0, 0, 0, 0));
            helmets.Add("Navy Hood (Mind +1)", (0, 1, 0, 0, 0, 0, 0, 0));
            helmets.Add("Imp Head Wolf (End +2)", (0, 0, 2, 0, 0, 0, 0, 0));
            helmets.Add("Imp Head Fanged (Str +2)", (0, 0, 0, 2, 0, 0, 0, 0));
            helmets.Add("Imp Head Long-Tongued (Dex +2)", (0, 0, 0, 0, 2, 0, 0, 0));
            helmets.Add("Imp Head Cat (Int +2)", (0, 0, 0, 0, 0, 2, 0, 0));
            helmets.Add("Imp Head Corpse (Fai +2)", (0, 0, 0, 0, 0, 0, 2, 0));
            helmets.Add("Imp Head Elder (Arc +2)", (0, 0, 0, 0, 0, 0, 0, 2));
            helmets.Add("Queen's Crescent Crown (Int +3)", (0, 0, 0, 0, 0, 3, 0, 0));
            helmets.Add("Ruler's Mask (Fai +1)", (0, 0, 0, 0, 0, 0, 1, 0));
            helmets.Add("Consort's Mask (Dex +1)", (0, 0, 0, 0, 1, 0, 0, 0));
            helmets.Add("Omensmirk Mask (Str +2)", (0, 0, 0, 2, 0, 0, 0, 0));
            helmets.Add("Marais Mask (Arc +1)", (0, 0, 0, 0, 0, 0, 0, 1));
            helmets.Add("Mask of Confidence (Arc +3)", (0, 0, 0, 0, 0, 0, 0, 3));
            helmets.Add("Albinauric Mask (Arc +4)", (0, 0, 0, 0, 0, 0, 0, 4));
            helmets.Add("Silver Tear Mask (Arc +8)", (0, 0, 0, 0, 0, 0, 0, 8));
            helmets.Add("Preceptor's Big Hat (Mind +3)", (0, 3, 0, 0, 0, 0, 0, 0));
            helmets.Add("Okina Mask (Dex +3)", (0, 0, 0, 0, 3, 0, 0, 0));
            helmets.Add("Sacred Crown Helm (Fai +1)", (0, 0, 0, 0, 0, 0, 1, 0));
            helmets.Add("Haligtree Helm (Fai +1)", (0, 0, 0, 0, 0, 0, 1, 0));
            helmets.Add("Haligtree Knight Helm (Fai +2)", (0, 0, 0, 0, 0, 0, 2, 0));
            helmets.Add("Greathood (Int +2, Fai +2)", (0, 0, 0, 0, 0, 2, 2, 0));

            // add the helmets to the combo-box
            foreach(var helmet in helmets)
            {
                UI_cbox_Helmets.Items.Add(helmet.Key);
            }
            UI_cbox_Helmets.SelectedIndexChanged -= UI_cbox_Helmets_SelectedIndexChanged;
            UI_cbox_Helmets.SelectedIndex = 0;
            UI_cbox_Helmets.SelectedIndexChanged += UI_cbox_Helmets_SelectedIndexChanged;
            #endregion

            #region Add Talismans
            talismans.Add("None", (0, 0, 0, 0, 0, 0, 0, 0));
            talismans.Add("Radagon's Scarseal", (3, 0, 3, 3, 3, 0, 0, 0));
            talismans.Add("Radagon's Soreseal", (5, 0, 5, 5, 5, 0, 0, 0));
            talismans.Add("Marika's Scarseal", (0, 3, 0, 0, 0, 3, 3, 3));
            talismans.Add("Marika's Soreseal", (0, 5, 0, 0, 0, 5, 5, 5));
            talismans.Add("Starscourge Heirloom", (0, 0, 0, 5, 0, 0, 0, 0));
            talismans.Add("Prosthesis-Wearer Heirloom", (0, 0, 0, 0, 5, 0, 0, 0));
            talismans.Add("Stargazer Heirloom", (0, 0, 0, 0, 0, 5, 0, 0));
            talismans.Add("Two Fingers Heirloom", (0, 0, 0, 0, 0, 0, 5, 0));
            talismans.Add("Millicent's Prosthesis", (0, 0, 0, 0, 5, 0, 0, 0));

            // add each of the talismans to each of the combo-box's
            foreach (var item in talismans)
            {
                UI_cbox_tali1.Items.Add(item.Key);
                UI_cbox_tali2.Items.Add(item.Key);
                UI_cbox_tali3.Items.Add(item.Key);
                UI_cbox_tali4.Items.Add(item.Key);
            }
            UI_cbox_tali1.SelectedIndex = 0;
            UI_cbox_tali2.SelectedIndex = 0;
            UI_cbox_tali3.SelectedIndex = 0;
            UI_cbox_tali4.SelectedIndex = 0;

            foreach (var cbox in UI_gbox_talis.Controls.OfType<ComboBox>())
            {
                cbox.SelectedIndexChanged += Cbox_SelectedIndexChanged;
            }
            #endregion

            #region physick
            foreach (var cbox in UI_gbox_wond.Controls.OfType<CheckBox>())
            {
                cbox.CheckedChanged += Cbox_CheckedChanged;
            }
            #endregion
        }

        #region UI Changing
        private void UI_cbox_Helmets_SelectedIndexChanged(object sender, EventArgs e)
        {
            EquipmentChanged();
        }

        private void UI_cbox_Common_CheckedChanged(object sender, EventArgs e)
        {
            EquipmentChanged();
        }

        private void Cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Talismans changing
            // Temporarily detach the event handler
            UI_cbox_tali1.SelectedIndexChanged -= Cbox_SelectedIndexChanged;
            UI_cbox_tali2.SelectedIndexChanged -= Cbox_SelectedIndexChanged;
            UI_cbox_tali3.SelectedIndexChanged -= Cbox_SelectedIndexChanged;
            UI_cbox_tali4.SelectedIndexChanged -= Cbox_SelectedIndexChanged;

            // Copy the talismans 4 times
            List<string> copy1 = new List<string>(talismans.Keys);
            List<string> copy2 = new List<string>(talismans.Keys);
            List<string> copy3 = new List<string>(talismans.Keys);
            List<string> copy4 = new List<string>(talismans.Keys);

            // Get the current Selected talisman for each
            string tali1 = UI_cbox_tali1.SelectedItem?.ToString();
            string tali2 = UI_cbox_tali2.SelectedItem?.ToString();
            string tali3 = UI_cbox_tali3.SelectedItem?.ToString();
            string tali4 = UI_cbox_tali4.SelectedItem?.ToString();

            // remove the selected talisman from the other cboxs
            if (tali1 != "None")
            {
                copy2.Remove(tali1); copy3.Remove(tali1); copy4.Remove(tali1);
            }
            if (tali2 != "None")
            {
                copy1.Remove(tali2); copy4.Remove(tali2); copy3.Remove(tali2);
            }
            if (tali3 != "None")
            {
                copy1.Remove(tali3); copy2.Remove(tali3); copy4.Remove(tali3);
            }
            if (tali4 != "None")
            {
                copy1.Remove(tali4); copy2.Remove(tali4); copy3.Remove(tali4);
            }

            #region Too many ifs...
            if (tali1 == "Radagon's Soreseal")
            {
                copy2.Remove("Radagon's Scarseal");
                copy3.Remove("Radagon's Scarseal");
                copy4.Remove("Radagon's Scarseal");
            }
            if (tali1 == "Radagon's Scarseal")
            {
                copy2.Remove("Radagon's Soreseal");
                copy3.Remove("Radagon's Soreseal");
                copy4.Remove("Radagon's Soreseal");
            }
            if (tali1 == "Marika's Soreseal")
            {
                copy2.Remove("Marika's Scarseal");
                copy3.Remove("Marika's Scarseal");
                copy4.Remove("Marika's Scarseal");
            }
            if (tali1 == "Marika's Scarseal")
            {
                copy2.Remove("Marika's Soreseal");
                copy3.Remove("Marika's Soreseal");
                copy4.Remove("Marika's Soreseal");
            }

            if (tali2 == "Radagon's Soreseal")
            {
                copy1.Remove("Radagon's Scarseal");
                copy3.Remove("Radagon's Scarseal");
                copy4.Remove("Radagon's Scarseal");
            }
            if (tali2 == "Radagon's Scarseal")
            {
                copy1.Remove("Radagon's Soreseal");
                copy3.Remove("Radagon's Soreseal");
                copy4.Remove("Radagon's Soreseal");
            }
            if (tali2 == "Marika's Soreseal")
            {
                copy1.Remove("Marika's Scarseal");
                copy3.Remove("Marika's Scarseal");
                copy4.Remove("Marika's Scarseal");
            }
            if (tali2 == "Marika's Scarseal")
            {
                copy1.Remove("Marika's Soreseal");
                copy3.Remove("Marika's Soreseal");
                copy4.Remove("Marika's Soreseal");
            }

            if (tali3 == "Radagon's Soreseal")
            {
                copy2.Remove("Radagon's Scarseal");
                copy1.Remove("Radagon's Scarseal");
                copy4.Remove("Radagon's Scarseal");
            }
            if (tali3 == "Radagon's Scarseal")
            {
                copy2.Remove("Radagon's Soreseal");
                copy1.Remove("Radagon's Soreseal");
                copy4.Remove("Radagon's Soreseal");
            }
            if (tali3 == "Marika's Soreseal")
            {
                copy2.Remove("Marika's Scarseal");
                copy1.Remove("Marika's Scarseal");
                copy4.Remove("Marika's Scarseal");
            }
            if (tali3 == "Marika's Scarseal")
            {
                copy2.Remove("Marika's Soreseal");
                copy1.Remove("Marika's Soreseal");
                copy4.Remove("Marika's Soreseal");
            }

            if (tali4 == "Radagon's Soreseal")
            {
                copy2.Remove("Radagon's Scarseal");
                copy3.Remove("Radagon's Scarseal");
                copy1.Remove("Radagon's Scarseal");
            }
            if (tali4 == "Radagon's Scarseal")
            {
                copy2.Remove("Radagon's Soreseal");
                copy3.Remove("Radagon's Soreseal");
                copy1.Remove("Radagon's Soreseal");
            }
            if (tali4 == "Marika's Soreseal")
            {
                copy2.Remove("Marika's Scarseal");
                copy3.Remove("Marika's Scarseal");
                copy1.Remove("Marika's Scarseal");
            }
            if (tali4 == "Marika's Scarseal")
            {
                copy2.Remove("Marika's Soreseal");
                copy3.Remove("Marika's Soreseal");
                copy1.Remove("Marika's Soreseal");
            }
            #endregion

            // clear each of the cboxes
            UI_cbox_tali1.Items.Clear();
            UI_cbox_tali2.Items.Clear();
            UI_cbox_tali3.Items.Clear();
            UI_cbox_tali4.Items.Clear();

            // re-add the selections
            foreach (string item in copy1)
            {
                UI_cbox_tali1.Items.Add(item);
            }
            foreach (string item in copy2)
            {
                UI_cbox_tali2.Items.Add(item);
            }
            foreach (string item in copy3)
            {
                UI_cbox_tali3.Items.Add(item);
            }
            foreach (string item in copy4)
            {
                UI_cbox_tali4.Items.Add(item);
            }

            // reset the indexes back where they were
            UI_cbox_tali1.SelectedItem = tali1;
            UI_cbox_tali2.SelectedItem = tali2;
            UI_cbox_tali3.SelectedItem = tali3;
            UI_cbox_tali4.SelectedItem = tali4;

            // Reattach the event handler
            UI_cbox_tali1.SelectedIndexChanged += Cbox_SelectedIndexChanged;
            UI_cbox_tali2.SelectedIndexChanged += Cbox_SelectedIndexChanged;
            UI_cbox_tali3.SelectedIndexChanged += Cbox_SelectedIndexChanged;
            UI_cbox_tali4.SelectedIndexChanged += Cbox_SelectedIndexChanged;
            #endregion

            EquipmentChanged();
        }

        private void Cbox_CheckedChanged(object sender, EventArgs e)
        {
            #region physick changing
            if (sender is CheckBox checkBox)
            {
                if (checkBox.Checked)
                {
                    // Check if there are already two checked checkboxes
                    if (checkedBoxes.All(cb => cb != null))
                    {
                        // Uncheck the first checkbox in the array
                        checkedBoxes[0].Checked = false;
                        checkedBoxes[0] = checkedBoxes[1]; // Shift the second checkbox to the first position
                    }

                    // Store the reference to the current checkbox
                    if (checkedBoxes[0] == null)
                    {
                        checkedBoxes[0] = checkBox;
                    }
                    else if (checkedBoxes[1] == null)
                    {
                        checkedBoxes[1] = checkBox;
                    }
                    else
                    {
                        checkedBoxes[0] = checkBox;
                    }
                }
                else
                {
                    // If a checkbox is unchecked, reset the array
                    if (checkedBoxes[0] == checkBox)
                    {
                        checkedBoxes[0] = null;
                    }
                    else if (checkedBoxes[1] == checkBox)
                    {
                        checkedBoxes[1] = null;
                    }
                }
            }
            #endregion

            EquipmentChanged();
        }

        private void UI_cbox_All_CheckedChanged(object sender, EventArgs e)
        {
            EquipmentChanged();
        }

        private void UI_cbox_2hand_CheckedChanged(object sender, EventArgs e)
        {
            EquipmentChanged();
        }

        private void UI_cbox_Godrick_CheckedChanged(object sender, EventArgs e)
        {
            EquipmentChanged();
        }

        private void UI_btn_reset_Click(object sender, EventArgs e)
        {
            // unselect everything
            UI_cbox_2hand.Checked = false;
            UI_cbox_Common.Checked = false;
            UI_cbox_Dex.Checked = false;
            UI_cbox_fai.Checked = false;
            UI_cbox_int.Checked = false;
            UI_cbox_Str.Checked = false;
            UI_cbox_Godrick.Checked = false;
            UI_cbox_All.Checked = false;

            UI_cbox_Helmets.SelectedIndex = 0;
            foreach (var cbox in UI_gbox_talis.Controls.OfType<ComboBox>())
            {
                cbox.SelectedIndex = 0;
            }
        }
        #endregion

        #region DGV Styling
        //*************************************************************************************
        //Method:     private void DGVStyleSpells()
        //Purpose:    Styles the DGV for showing all the spells
        //Parameters: N/A
        //Returns:    N/A
        //*************************************************************************************
        private void DGVStyleSpells()
        {
            UI_DGV_Spells.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UI_DGV_Spells.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Spells.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Spells.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Spells.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        //*************************************************************************************
        //Method:     private void DGVStyleWeapons()
        //Purpose:    Styles the DGV for showing all the weapons
        //Parameters: N/A
        //Returns:    N/A
        //*************************************************************************************
        private void DGVStyleWeapons()
        {
            UI_DGV_Weapons.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UI_DGV_Weapons.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Weapons.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Weapons.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Weapons.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Weapons.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            UI_DGV_Weapons.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        #endregion

        #region Equpiment Changing
        //*************************************************************************************
        //Method:     private void EquipmentChanged()
        //Purpose:    Change the player's stats based on UI controls
        //Parameters: N/A
        //Returns:    N/A
        //*************************************************************************************
        private void EquipmentChanged()
        {
            // Initialize stats back to default
            int Vig = 10; int Mind = 10; int End = 10; int Str = 10; int Dex = 10;
            int Int = 10; int Fai = 10; int Arc = 10;

            // Update Stats based on Helmet
            Vig += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].Vig;
            Mind += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].Mind;
            End += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].End;
            Str += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].Str;
            Dex += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].Dex;
            Int += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].Int;
            Fai += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].Fai;
            Arc += helmets[UI_cbox_Helmets.SelectedItem?.ToString()].Arc;

            // Update Faith if they're wearing commoner's garb
            if (UI_cbox_Common.Checked)
            {
                Fai++;
            }

            // update stats based on talismans selected
            foreach (var cbox in UI_gbox_talis.Controls.OfType<ComboBox>())
            {
                Vig += talismans[cbox.SelectedItem?.ToString()].Vig;
                Mind += talismans[cbox.SelectedItem?.ToString()].Mind;
                End += talismans[cbox.SelectedItem?.ToString()].End;
                Str += talismans[cbox.SelectedItem?.ToString()].Str;
                Dex += talismans[cbox.SelectedItem?.ToString()].Dex;
                Int += talismans[cbox.SelectedItem?.ToString()].Int;
                Fai += talismans[cbox.SelectedItem?.ToString()].Fai;
                Arc += talismans[cbox.SelectedItem?.ToString()].Arc;
            }

            // Add the physicks to the stats
            if (UI_cbox_Dex.Checked) { Dex += 10; }
            if (UI_cbox_fai.Checked) { Fai += 10; }
            if (UI_cbox_Str.Checked) { Str += 10; }
            if (UI_cbox_int.Checked) { Int += 10; }

            // godrick's great rune +5 to all stats
            if (UI_cbox_Godrick.Checked)
            {
                Vig += 5; Mind += 5; End += 5; Str += 5; Dex += 5; Int += 5; Fai += 5; Arc += 5;
            }

            // 1.5 x to strength
            if (UI_cbox_2hand.Checked) { Str = (Str * 3 / 2); }

            // if the view all is checked... everything 99
            if (UI_cbox_All.Checked)
            {
                Vig = 99; Mind = 99; End = 99; Str = 99; Dex = 99; Int = 99; Fai = 99; Arc = 99;
            }

            // Assign the Stats back to the player
            player = (Vig, Mind, End, Str, Dex, Int, Fai, Arc);

            // Change the Labels to match the player's Stats
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "VigVal").Text = $"{Vig}";
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "MindVal").Text = $"{Mind}";
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "EndVal").Text = $"{End}";
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "StrVal").Text = $"{Str}";
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "DexVal").Text = $"{Dex}";
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "IntVal").Text = $"{Int}";
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "FaiVal").Text = $"{Fai}";
            UI_table_Stats.Controls.OfType<Label>().FirstOrDefault(c => c.Tag?.ToString() == "ArcVal").Text = $"{Arc}";

            // Show the new matched spells and weapons
            MatchWeapons();
            MatchSpells();
        }
        #endregion

        #region LINQy Matchy
        //*************************************************************************************
        //Method:     private void MatchWeapons()
        //Purpose:    Find the matched weapons and output to the DGV
        //Parameters: N/A
        //Returns:    N/A
        //*************************************************************************************
        private void MatchWeapons()
        {
            var matched = from weapon
                          in weapons
                          where weapon.Int <= player.Int &&
                                weapon.Fai <= player.Fai &&
                                weapon.Arc <= player.Arc &&
                                weapon.Str <= player.Str &&
                                weapon.Dex <= player.Dex
                          select weapon;

            // add the weapons to the binding source and style
            bsWeapon.DataSource = matched;
            DGVStyleWeapons();
        }

        //*************************************************************************************
        //Method:     private void MatchSpells()
        //Purpose:    Find the matched Spells and output to the DGV
        //Parameters: N/A
        //Returns:    N/A
        //*************************************************************************************
        private void MatchSpells()
        {
            var matched = from Spell
                          in spells
                          where Spell.Int <= player.Int &&
                                Spell.Fai <= player.Fai &&
                                Spell.Arc <= player.Arc
                          select Spell;

            // add the weapons to the binding source and style
            bsSpell.DataSource = matched;
            DGVStyleSpells();
        }
        #endregion
    }
}
