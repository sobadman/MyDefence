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

        //private�� ���� instance�� ��ȯ�ϴ� �޼���
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
