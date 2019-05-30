using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace assignment.Models
{
    public class BeachEf
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string NameFr { get; set; }
        public string Address { get; set; }
        public string AddressFr { get; set; }
        public string BeachType { get; set; }
        public string Accessible { get; set; }
        public string Open { get; set; }
        public string Notes { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }
        public string Link { get; set; }
        public string LinkFr { get; set; }
        public string LinkLabel { get; set; }
        public string LinkLab1 { get; set; }
        public string LinkDescr { get; set; }
        public string LinkDes1 { get; set; }
        public string PostalCode { get; set; }
        public string Photo { get; set; }
        public long GeometryId { get; set; }

        public virtual CoordinatesEf Geometry { get; set; }
    }

    public class CoordinatesEf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public CoordinatesEf()
        {
            //Beach = new HashSet<BeachEf>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BeachEf> Beach { get; set; }

    }

    public class BeachEfInfo
    {
        public BeachEf beach { get; set; }
        public CoordinatesEf geometry { get; set; }
    }

}
