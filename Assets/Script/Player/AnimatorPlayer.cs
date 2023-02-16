using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorPlayer
{
    public static class States
    {
        public const string Idle = nameof(Idle); 
        public const string Run = nameof(Run);
        public const string Fall = nameof(Fall);
        public const string Climb = nameof(Climb);
        public const string Attack = nameof(Attack);
        public const string Crawl = nameof(Crawl);
        public const string Win = nameof(Win);
        public const string Die = nameof(Die);
    }
}
