using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L01_Entities.Models
{
    [Table("Instrument_T")]
    public class Instrument : BaseEntity
    {
        public InstrumentState? InstrumentState { get; set; }
        public InstrumentType InstrumentType { get; set; }

     
        public virtual ICollection<InstrumentInformation> InstrumentInformations { get; set; }


     
        public virtual ICollection<InstrumentCycle> InstrumentCycles { get; set; }

        

      
        public virtual ICollection<Request> Requests { get; set; }

        public int DEVen { get; set; }
        public long InsCode { get; set; }
        public string InstrumentID { get; set; }
        public string CValMne { get; set; }
        public string LVal18 { get; set; }
        public string CSocCSAC { get; set; }
        public string LSoc30 { get; set; }
        public string LVal18AFC { get; set; }
        public string LVal30 { get; set; }
        public string CIsin { get; set; }
        public decimal QNmVlo { get; set; }
        public decimal ZTitad { get; set; }
        public int DESop { get; set; }
        public int YOPSJ { get; set; }
        public string CGdSVal { get; set; }
        public string CGrValCot { get; set; }
        public int DInMar { get; set; }
        public int YUniExpP { get; set; }
        public string YMarNSC { get; set; }
     
        public long? CComVal { get; set; }
        [ForeignKey("CComVal")]
        public virtual Board Board { get; set; }

       
        public long? CSecVal { get; set; }
        [ForeignKey("CSecVal")]
        public virtual Sector Sector { get; set; }

       
        public long? CSoSecVal { get; set; }
        [ForeignKey("CSoSecVal")]
        public virtual SubSector SubSector { get; set; }

        public int YDeComp { get; set; }
        public decimal PSaiSMaxOkValMdinOccurs { get; set; }
        public decimal PSaiSMinOkValMdinOccurs { get; set; }
        public long BaseVol { get; set; }
        public int YVal { get; set; }
        public int QPasCotFxeVal { get; set; }
        public int QQtTranMarVal { get; set; }
        public int Flow { get; set; }
        public long QtitMinSaiOmProd { get; set; }
        public long QtitMaxSaiOmProd { get; set; }
        public short Valid { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? CloseDate { get; set; }

      
        public virtual ICollection<InstrumentAnalayzeBuy> InstrumentAnalayzeBuys { get; set; }

        public virtual ICollection<InstrumentAnalayzeSell> InstrumentAnalayzeSells { get; set; }

    }
}
