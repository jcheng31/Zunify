using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zunify.Models
{
    public class Track
    {
        public static Track FromXmlStringFactory(string xmlString)
        {
            if (String.IsNullOrEmpty(xmlString))
            {
                throw new ArgumentException();
            }

            return new Track();
        }
    }
}
