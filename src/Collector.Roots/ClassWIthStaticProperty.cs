using System.Collections.Generic;

namespace Collector.Roots
{
    public class ClassWithStaticProperty
    {
        public static byte[] StaticProperty = new byte[1000 * 1000 * 1000];

        static ClassWithStaticProperty()
        {
            for (int i = 0; i < StaticProperty.Length; i++)
            {
                StaticProperty[i] = 1;
            }
        }
    }
}