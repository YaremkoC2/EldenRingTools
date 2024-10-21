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
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Resources;
using System.Diagnostics;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Diagnostics.Contracts;

namespace EldenRingLevel1
{
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// Class : Weapon - holds data for each weapon
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public class Weapon
    {
        // Auto properties for the weapon
        public string Name { get; private set; }
        public string Category { get; private set; }
        public int Str { get; private set; }
        public int Dex { get; private set; }
        public int Int { get; private set; }
        public int Fai { get; private set; }
        public int Arc { get; private set; }

        // simple constructor for each weapon
        public Weapon(string name, string cat, int str, int dex, int _int, int fai, int arc)
        {
            Name = name; Category = cat; Str = str; Dex = dex; Int = _int; Fai = fai; Arc = arc; 
        }

        //*****************************************************************************************
        //Method:     public static List<Weapon> LoadWeapons(string url, int howBad)
        //Purpose:    Creates weapons for the given url
        //Parameters: string url - the URL weapons are being loaded from
        //            int howBad - increase the indexes depending on how bad the url
        //Returns:    List of weapons of the category
        //*****************************************************************************************
        public static List<Weapon> LoadWeapons(string url, int howBad)
        {
            List<Weapon> weapons = new List<Weapon>(); // list to be returned

            // initialize stuff for the web request
            HtmlWeb web;
            HtmlDocument doc;

            // Try catch while we load the page
            try
            {
                web = new HtmlWeb();
                doc = web.Load(url);
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
                            string name = cells[0].InnerText.Trim().Replace("&nbsp;", "");
                            string cat = doc.DocumentNode.SelectSingleNode("//strong").InnerText.Trim().Replace("&nbsp;", "");
                            int.TryParse(cells[7 + howBad].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int str);
                            int.TryParse(cells[8 + howBad].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int dex);
                            int.TryParse(cells[9 + howBad].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int _int);
                            int.TryParse(cells[10 + howBad].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int fai);
                            int.TryParse(cells[11 + howBad].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int arc);

                            weapons.Add(new Weapon(name, cat, str, dex, _int, fai, arc));
                        }
                    }
                }
            }

            return weapons;
        }

        //*****************************************************************************************
        //Method:     public static List<Weapon> LoadFists(string url)
        //Purpose:    Creates weapons for the given url
        //Parameters: string url - the URL weapons are being loaded from
        //Returns:    List of weapons of the category
        //*****************************************************************************************
        public static List<Weapon> LoadFists(string url)
        {
            List<Weapon> weapons = new List<Weapon>(); // list to be returned

            // initialize stuff for the web request
            HtmlWeb web;
            HtmlDocument doc;

            // Try catch while we load the page
            try
            {
                web = new HtmlWeb();
                doc = web.Load(url);
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
                            string name = cells[0].InnerText.Trim().Replace("&nbsp;", "");
                            string cat = doc.DocumentNode.SelectSingleNode("//strong").InnerText.Trim().Replace("&nbsp;", "");

                            int str = 0;
                            HtmlNode strNode = cells[8].SelectSingleNode(".//p[1]");
                            if (strNode != null)
                            {
                                int.TryParse(strNode.InnerText.Trim().Replace("&nbsp;", ""), out str);
                            }

                            int dex = 0;
                            HtmlNode dexNode = cells[9].SelectSingleNode(".//p[1]");
                            if (dexNode != null)
                            {
                                int.TryParse(dexNode.InnerText.Trim().Replace("&nbsp;", ""), out dex);
                            }

                            int _int = 0;
                            HtmlNode intNode = cells[10].SelectSingleNode(".//p[1]");
                            if (intNode != null)
                            {
                                int.TryParse(intNode.InnerText.Trim().Replace("&nbsp;", ""), out _int);
                            }

                            int fai = 0;
                            HtmlNode faiNode = cells[11].SelectSingleNode(".//p[1]");
                            if (faiNode != null)
                            {
                                int.TryParse(faiNode.InnerText.Trim().Replace("&nbsp;", ""), out fai);
                            }

                            int arc = 0;
                            HtmlNode arcNode = cells[12].SelectSingleNode(".//p[1]");
                            if (arcNode != null)
                            {
                                int.TryParse(arcNode.InnerText.Trim().Replace("&nbsp;", ""), out arc);
                            }

                            weapons.Add(new Weapon(name, cat, str, dex, _int, fai, arc));
                        }
                    }
                }
            }

            return weapons;
        }

        //*****************************************************************************************
        //Method:     public static List<Weapon> LoadBows(string url)
        //Purpose:    Creates weapons for the given url
        //Parameters: string url - the URL weapons are being loaded from
        //Returns:    List of weapons of the category
        //*****************************************************************************************
        public static List<Weapon> LoadBows(string url)
        {
            List<Weapon> weapons = new List<Weapon>(); // list to be returned

            // initialize stuff for the web request
            HtmlWeb web;
            HtmlDocument doc;

            // Try catch while we load the page
            try
            {
                web = new HtmlWeb();
                doc = web.Load(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Application.Exit();
                return null;
            }

            // get the second table in the HTML document
            HtmlNode secondTable = doc.DocumentNode.SelectNodes("//table")[1];

            if (secondTable != null)
            {
                // get all the table rows in the first table
                HtmlNodeCollection rows = secondTable.SelectNodes(".//tr");

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
                            string name = cells[0].InnerText.Trim().Replace("&nbsp;", "");
                            string cat = doc.DocumentNode.SelectSingleNode("//strong").InnerText.Trim().Replace("&nbsp;", "");

                            // Retrieve the second <p> element within each <td> element
                            int.TryParse(cells[8].SelectNodes("p")[1].InnerText.Trim().Replace("&nbsp;", ""), out int str);
                            int.TryParse(cells[9].SelectNodes("p")[1].InnerText.Trim().Replace("&nbsp;", ""), out int dex);

                            int _int;
                            HtmlNode intNode = cells[10].SelectSingleNode(".//p[2]");
                            if (intNode != null)
                            {
                                int.TryParse(cells[10].SelectNodes("p")[1].InnerText.Trim().Replace("&nbsp;", ""), out _int);
                            }
                            else { _int = 0; }

                            int fai;
                            HtmlNode faiNode = cells[11].SelectSingleNode(".//p[2]");
                            if (faiNode != null)
                            {
                                int.TryParse(cells[11].SelectNodes("p")[1].InnerText.Trim().Replace("&nbsp;", ""), out fai);
                            }
                            else { fai = 0; }
                            
                            int.TryParse(cells[12].SelectNodes("p")[1].InnerText.Trim().Replace("&nbsp;", ""), out int arc);

                            weapons.Add(new Weapon(name, cat, str, dex, _int, fai, arc));
                        }
                    }
                }
            }

            return weapons;
        }

        //*****************************************************************************************
        //Method:     public static List<Weapon> LoadXBows(string url)
        //Purpose:    Creates weapons for the given url
        //Parameters: string url - the URL weapons are being loaded from
        //Returns:    List of weapons of the category
        //*****************************************************************************************
        public static List<Weapon> LoadXBows(string url)
        {
            List<Weapon> weapons = new List<Weapon>(); // list to be returned

            // initialize stuff for the web request
            HtmlWeb web;
            HtmlDocument doc;

            // Try catch while we load the page
            try
            {
                web = new HtmlWeb();
                doc = web.Load(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Application.Exit();
                return null;
            }

            // get the second table in the HTML document
            HtmlNode secondTable = doc.DocumentNode.SelectNodes("//table")[1];

            if (secondTable != null)
            {
                // get all the table rows in the first table
                HtmlNodeCollection rows = secondTable.SelectNodes(".//tr");

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
                            string name = cells[0].InnerText.Trim().Replace("&nbsp;", "");
                            string cat = doc.DocumentNode.SelectSingleNode("//strong").InnerText.Trim().Replace("&nbsp;", "");
                            int.TryParse(cells[8].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int str);
                            int.TryParse(cells[9].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int dex);
                            int.TryParse(cells[10].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int _int);
                            int.TryParse(cells[11].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int fai);
                            int.TryParse(cells[12].SelectSingleNode(".//p[1]").InnerText.Trim().Replace("&nbsp;", ""), out int arc);

                            weapons.Add(new Weapon(name, cat, str, dex, _int, fai, arc));
                        }
                    }
                }
            }

            return weapons;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// Class : Spell - holds data for each spell
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public class Spell
    {
        // Auto Properties for the spell
        public string Name { get; private set; }
        public string Category { get; private set; }
        public int Int { get; private set; }
        public int Fai { get; private set; }
        public int Arc { get; private set; }

        // simple constructor for each spell
        public Spell(string name, string cat, int _int, int fai, int arc)
        {
            Name = name; Category = cat; Int = _int; Fai = fai; Arc = arc;
        }

        //*****************************************************************************************
        //Method:     public static List<Weapon> LoadSpells(string url)
        //Purpose:    Creates spells for the given url
        //Parameters: string url - the URL weapons are being loaded from
        //Returns:    List of spells of the category
        //*****************************************************************************************
        public static List<Spell> LoadSpells(string url)
        {
            List<Spell> spells = new List<Spell>(); // list to be returned

            // initialize stuff for the web request
            HtmlWeb web;
            HtmlDocument doc;

            // Try catch while we load the page
            try
            {
                web = new HtmlWeb();
                doc = web.Load(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Application.Exit();
                return null;
            }

            // get the first table in the HTML document
            HtmlNode table = doc.DocumentNode.SelectNodes("//table")[1];

            if (table != null)
            {
                // get all the table rows in the first table
                HtmlNodeCollection rows = table.SelectNodes(".//tr");

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
                            string name = cells[0].InnerText.Trim().Replace("&nbsp;", "");
                            string cat = doc.DocumentNode.SelectSingleNode("//strong").InnerText.Trim().Replace("&nbsp;", "");
                            int.TryParse(cells[4].InnerText.Trim().Replace("&nbsp;", ""), out int _int);
                            int.TryParse(cells[5].InnerText.Trim().Replace("&nbsp;", ""), out int fai);
                            int.TryParse(cells[6].InnerText.Trim().Replace("&nbsp;", ""), out int arc);

                            spells.Add(new Spell(name, cat, _int, fai, arc));
                        }
                    }
                }
            }

            return spells;
        }
    }
}
