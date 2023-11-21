using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4Gerencia.Models;
public class Metadata_DashBoardUser : BaseModel
{
    public int dashu_id { get; set; }
    public int dash_id { get; set; }
    public string suc_id { get; set; }
    public string usu_id { get; set; }
    public string dash_datus { get; set; }
    public string dash_posi { get; set; }
    public bool dash_activ { get; set; }

}