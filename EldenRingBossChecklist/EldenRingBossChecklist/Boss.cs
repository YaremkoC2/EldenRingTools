using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace EldenRingBossChecklist
{
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// Class : Boss - holds data for each boss
    ///////////////////////////////////////////////////////////////////////////////////////////////
    internal class Boss
    {
        public string Name { get; private set; }
        public string Location { get; private set; }
        public string Category { get; private set; }
        public string Region { get; private set; }

        // simple constructor for bosses
        public Boss(string name, string location, string category, string region)
        {
            Name = name;
            Location = location;
            Category = category;
            Region = region;
        }

        //*****************************************************************************************
        //Method:     public static List<Boss> LoadBosses(string url)
        //Purpose:    Creates bosses from the given url
        //Parameters: N/A
        //Returns:    List of bosses
        //*****************************************************************************************
        public static List<Boss> LoadBosses()
        {
            List<Boss> bosses = new List<Boss>();

            // initialize stuff for the web request
            HtmlWeb web;
            HtmlDocument doc;

            // Try catch while we load the page
            try
            {
                web = new HtmlWeb();
                doc = web.Load("https://mapgenie.io/elden-ring/checklist");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Application.Exit();
                return null;
            }

            // get the first table in the HTML document
            HtmlNode firstTable = doc.DocumentNode.SelectSingleNode("//table");

            if (firstTable != null)
            {
                // get all the table rows in the first table
                HtmlNodeCollection rows = firstTable.SelectNodes(".//tr");

                if (rows != null && rows.Count > 0)
                {
                    // go through each of the rows in the table
                    foreach (HtmlNode row in rows)
                    {
                        // get all of the cells in each row
                        HtmlNodeCollection cells = row.SelectNodes("td");

                        if (cells != null && cells.Count > 0)
                        {
                            // Pull the data from the html then add the new weapon
                            string name = cells[2].InnerText.Trim().Replace("&nbsp;", "").Replace("&#039;", "'").Replace("&amp;", "&");
                            string location = "";

                            HtmlNode locationNode = cells[1].SelectSingleNode("a");
                            if (locationNode != null)
                            {
                                location = locationNode.GetAttributeValue("href", string.Empty);
                            }

                            string category = cells[3].InnerText.Trim().Replace("&nbsp;", "");
                            string region = cells[4].InnerText.Trim().Replace("&nbsp;", "");

                            bosses.Add(new Boss(name, location, category, region));
                        }
                    }
                }
            }

            return bosses;
        }
    }
}
