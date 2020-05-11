using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JsonOutput
{
    public class ExportJSON
    {
        public void Add(Exception ex)
        {
            try
            {
                string path = @"C:\Orion\Exp.json";
                string rawJson;
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                rawJson = File.ReadAllText(path);
                var ec = JsonConvert.DeserializeObject<ExpCollection>(rawJson);

                if (ec != null)
                {
                    int Count = ec.Exceptions.Count;
                    Exp Exps = new Exp
                    {
                        Id = ++Count,
                        Time = DateTime.Now.ToShortTimeString(),
                        Date = DateTime.Today.ToShortDateString(),
                        Message = ex.Message.ToString(),
                        StackTrace = ex.StackTrace.ToString()
                    };
                    ec.Exceptions.Add(Exps);
                    string serializedJson = JsonConvert.SerializeObject(ec, Formatting.Indented);
                    File.WriteAllText(path, serializedJson);
                }
                else
                {
                    ExpCollection exp = new ExpCollection
                    {
                        Exceptions = new List<Exp>()
                    };
                    Exp Exps = new Exp
                    {
                        Id = 1,
                        Time = DateTime.Now.ToShortTimeString(),
                        Date = DateTime.Today.ToShortDateString(),
                        Message = ex.Message.ToString(),
                        StackTrace = ex.StackTrace.ToString()
                    };
                    exp.Exceptions.Add(Exps);
                    string serializedJson = JsonConvert.SerializeObject(exp, Formatting.Indented);
                    File.WriteAllText(path, serializedJson);
                }
                //string jsonFile = @"Exceptions.Json";
                //string rawJson = File.ReadAllText(jsonFile);
                //ExpCollection ec = new ExpCollection();
                //ec = JsonConvert.DeserializeObject<ExpCollection>(rawJson);
                ////int Count = ec.Exceptions.Count;
                //Exp Exps = new Exp
                //{
                //    Id = 1,
                //    Time = DateTime.Now.ToShortTimeString(),
                //    Date = DateTime.Today.ToShortDateString(),
                //    Message = ex.Message.ToString(),
                //    StackTrace = ex.StackTrace.ToString()
                //};
                //ec.Exceptions.Add(Exps);
                //string serializedJson = JsonConvert.SerializeObject(ec, Formatting.Indented);
                //File.WriteAllText(@"Exceptions.Json", serializedJson);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error : " + e.Message.ToString());
            }
        }
    }

    public class ExpCollection
    {
        public List<Exp> Exceptions { get; set; }
    }

    public class Exp
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Time { get; set; }

        [JsonProperty]
        public string Date { get; set; }

        [JsonProperty]
        public string Message { get; set; }

        [JsonProperty]
        public string StackTrace { get; set; }
    }
}