using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSampleTest.Models
{
    public class ColorsRepository
    {
        private static ColorsRepository colorRepository = new ColorsRepository();

        /// <summary>
        /// Get List of Colors
        /// </summary>
        public static ColorsRepository Current
        {
            get { return colorRepository; }
        }


        private List<Farbe> lstFarbe = new List<Farbe>()
        {
            new Farbe {ID=1, FarbeName="blau"},
            new Farbe {ID=2, FarbeName="grün"},
            new Farbe {ID=3, FarbeName="violett"},
            new Farbe {ID=4, FarbeName="rot"},
            new Farbe {ID=5, FarbeName="gelb"},
            new Farbe {ID=6, FarbeName="türkis"},
            new Farbe {ID=7, FarbeName="weiß"},
        };

        /// <summary>
        /// Get Color Info By ID
        /// </summary>
        /// <param name="ID">Color ID</param>
        /// <returns>Farbe</returns>
        public Farbe GetFarbe(int ID)
        {
            return lstFarbe.Where(p => p.ID == ID).FirstOrDefault();
        }

        /// <summary>
        /// Get Color Info By Name
        /// </summary>
        /// <param name="Name">Color Name</param>
        /// <returns>Farbe</returns>
        public Farbe GetFarbe(string Name)
        {
            return lstFarbe.Where(p => p.FarbeName == Name).FirstOrDefault();
        }
    }
}