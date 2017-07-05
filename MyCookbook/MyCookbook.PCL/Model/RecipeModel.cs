using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCookbook
{
    [Table("recipes")]
    public class RecipeModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250), Unique, NotNull]
        public string Title { get; set; }

        public List<IngredientData> Ingredients { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is RecipeModel)
            {
                var other = (RecipeModel)obj;
                return Title.Equals(other.Title);
            }

            return base.Equals(obj);
        }
    }

}
