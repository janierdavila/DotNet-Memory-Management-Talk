using System.Collections.Generic;

namespace Collector.Roots
{
    public class ClassWithRegularProperty
    {
        public byte[] RegularProperty = new byte[1000 * 1000 * 1000];

        public ClassWithRegularProperty()
        {
            for (int i = 0; i < RegularProperty.Length; i++)
            {
                RegularProperty[i] = 1;
            }
        }
    }
}