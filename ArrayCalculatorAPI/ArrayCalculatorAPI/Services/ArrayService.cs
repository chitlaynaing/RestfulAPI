using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayCalculatorAPI.Services
{
    public class ArrayService : IArrayService
    {
        public List<int> DeletePartArray(string queryString, int position)
        {
            List<int> result = new List<int>();

            try
            {
                List<string> productIds = queryString.Split('&').ToList();

                for (int i = 1; i < productIds.Count; i++)
                {
                    if (i != position)
                    {
                        bool isParsed;
                        int id;
                        int start = productIds[i].LastIndexOf("=") + 1;
                        int len = productIds[i].Length - start;

                        string value = productIds[i].Substring(start, len);

                        isParsed = int.TryParse(value, out id);

                        if (isParsed)
                            result.Add(id);
                        else
                            result.Add(0);
                    } 
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<int> ReverseArray(string queryString)
        {
            List<int> result = new List<int>();
            List<int> Params = new List<int>();

            try
            {
                List<string> productIds = queryString.Split('&').ToList();

                foreach (var productId in productIds)
                {
                    bool isParsed;
                    int id;
                    int start = productId.LastIndexOf("=") + 1;
                    int len = productId.Length - start;

                    string value = productId.Substring(start, len);

                    isParsed = int.TryParse(value, out id);

                    if (isParsed)
                        Params.Add(id);
                    else
                        Params.Add(0);
                }

                int index = productIds.Count;

                for (int i = 0; i < productIds.Count; i++)
                {
                    index--;
                    result.Add(Params.ElementAt(index));
                }

            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }

}
