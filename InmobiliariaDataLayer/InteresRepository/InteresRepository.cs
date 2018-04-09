using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaDataLayer.Connection;
using InmobiliariaLogicLayer.Persistence;
using InmobiliariaViewModels;

namespace InmobiliariaDataLayer.Lote
{
    public class InteresRepository: IReadPersistence
    {
        private PostConnection db;
        public InteresRepository()
        {
            db = new PostConnection();
        }
        
        public object FindForItem(object id)
        {
            object interes = null;//hacer cast a double.
            string query = "SELECT interes FROM lotificadora WHERE nombre = @text";
            using (var connection = PostConnection.Connection()){
                using (var command = db.Command(query)){
                    try{
                        connection.Open();
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@text", (string)id);
                        using (var reader = command.ExecuteReader()){
                            while (reader.Read()){
                                interes = Convert.ToDouble(reader["interes"]);
                            }
                        }
                    }catch(Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return interes;
        }

        public object FindAll()
        {
            var list = new List<TestInteresViewModels>();
            string query = "SELECT nombre, interes FROM lotificadora";
            using (var connection = PostConnection.Connection()) {
                using (var command = db.Command(query)) {
                    try {
                        connection.Open();
                        command.Connection = connection;
                        using (var reader = command.ExecuteReader()) {
                            while (reader.Read()){
                                list.Add(new TestInteresViewModels(){
                                    nombre = reader["nombre"].ToString(),
                                    interes = Convert.ToDouble(reader["interes"])
                                });
                            }
                        }
                    }catch(Exception ex){
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return list;
        }
    }
}
