using UnityEngine;

namespace SingletonDemo
{
    public class Singleton
    {
        private static Singleton instance;

        //
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        //private한 변수 instance를 반환하는 메서드
        /*public static Singleton Instance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }*/



    }
}
