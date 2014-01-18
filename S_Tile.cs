using libtcod;

namespace CSharpEntityComponentSystem
{
    struct Tile {
        public char tileChar;
        public TCODColor foreColor, backColor;
        public bool Walkable, Seethrough;
        public string Name, Description;
    }
}
