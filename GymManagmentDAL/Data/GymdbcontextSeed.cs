using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data
{
    public static class GymdbcontextSeed
    {

        public static bool DataSeeded (GymdbContext dbcontext)
        {

            try
            {
                var HasPlan = dbcontext.Plans.Any();
                var HasCategory = dbcontext.categories.Any();

                if (HasPlan && HasCategory) return false;
                if (!HasPlan)
                {
                    var plan = LoadDataFromFileJson<Plan>("plans.json");
                    dbcontext.Plans.AddRange(plan);

                }

                if (!HasCategory)
                {
                    var category = LoadDataFromFileJson<Category>("categories.json");
                    dbcontext.categories.AddRange(category);

                }

                return dbcontext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"seeding failed : {ex} ");
                return false;
            }
           
        }

        private static List<T> LoadDataFromFileJson<T> (string FileName)
        {
            var FilePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files",FileName);


            if (!File.Exists(FilePath)) throw new FileNotFoundException();

            string Data=File.ReadAllText(FilePath);
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<T>>(Data, options) ?? new List<T>();
                
        }


    }
}
