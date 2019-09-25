using System;

namespace Game
{
    class Enemy
    {
        public int Movement { get; set; }
        public string Direction { get; set; }
        public string Type { get; private set;}
        public Enemy (string type){
            Type = type;
            Movement = 0;
            Direction = "none";
        }
        
    }

}