using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook
{
    [Table("ingredients")]
    public class IngredientData
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        private int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }

        private List<string> _units = new List<string> {"cup", "tbsps", "tsp",
                                                       "quart", "oz", "gal", "qty"};
        [Ignore]
        public List<string> Units
        {
            get
            {
                return _units;
            }
        }

        public string SelectedUnit { get; set; }
    }
}
