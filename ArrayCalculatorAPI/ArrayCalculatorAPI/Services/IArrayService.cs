using System.Collections.Generic;

namespace ArrayCalculatorAPI.Services
{
    public interface IArrayService
    {
       List<int> ReverseArray(string query);
       List<int> DeletePartArray(string query,int position);

    }
}
