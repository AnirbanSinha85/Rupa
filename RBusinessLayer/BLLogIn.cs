using System.Data;
using RPropertyLayer;
using RDataLayer;

namespace RBusinessLayer
{
    public class BLLogIn
    {
        public DataTable BLCheckLogIn(PRLogIn objLogIn)
        {
            DLLogin obj = new DLLogin();
            return obj.DLCheckLogIn(objLogIn);
        }
    }
}
