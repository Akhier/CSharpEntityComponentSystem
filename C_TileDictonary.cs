using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libtcod;

namespace CSharpEntityComponentSystem
{
    class TileDictonary {
        public Dictionary<int, Tile> TileAttributes = new Dictionary<int,Tile>();
        public TileDictonary() {
            Dictionary<string,TCODColor> colorDictionary = new Dictionary<string,TCODColor>();
            colorDictionary["lightestgrey"] = TCODColor.lightestGrey;
            string tileDefinitions;
            using (System.IO.StreamReader SR = new System.IO.StreamReader("TileDefinitions")) {
                tileDefinitions = SR.ReadToEnd();
            }
            char[] splitter = new char[] { '{', '}', '\r', '\n' };
            string[] tileDefArray = tileDefinitions.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
            foreach (string fulldefinition in tileDefArray) {
                string[] stringsplitter = new string[] {"ID'", "'I "};
                string[] splitstring = fulldefinition.Split(stringsplitter, StringSplitOptions.RemoveEmptyEntries);
                int tileid = Convert.ToInt32(splitstring[1]);
                Tile tile;
                tile.backColor = TCODColor.darkestGrey;
                stringsplitter = new string[] { "NAME'", "'N" };
                splitstring = fulldefinition.Split(stringsplitter, StringSplitOptions.RemoveEmptyEntries);
                tile.Name = splitstring[1];
                stringsplitter = new string[] { "TILE'", "'T" };
                splitstring = fulldefinition.Split(stringsplitter, StringSplitOptions.RemoveEmptyEntries);
                tile.tileChar = Convert.ToChar(splitstring[1]);
                stringsplitter = new string[] { "DESCRIPTION'", "'D" };
                splitstring = fulldefinition.Split(stringsplitter, StringSplitOptions.RemoveEmptyEntries);
                tile.Description = splitstring[1];
                stringsplitter = new string[] { "COLOR'", "'C" };
                splitstring = fulldefinition.Split(stringsplitter, StringSplitOptions.RemoveEmptyEntries);
                tile.foreColor = colorDictionary[splitstring[1]];
                tile.Walkable = fulldefinition.Contains("WALKABLE");
                tile.Seethrough = fulldefinition.Contains("SEETHROUGH");
                TileAttributes[tileid] = tile;
            }
        }
    }
}
