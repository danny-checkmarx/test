using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test
{


    public class CPE
    {
        public CPE(string part, string vendor, string product, string version = "*", string update = "*", string edition = "*", string language = "*", string softwareEdition = "*", string targetSoftware = "*", string targetHardware = "*", string other = "*")
        {
            Part = part;
            Vendor = vendor;
            Product = product;
            Version = version;
            Update = update;
            Edition = edition;
            Language = language;
            SoftwareEdition = softwareEdition;
            TargetSoftware = targetSoftware;
            TargetHardware = targetHardware;
            Other = other;
        }
        public CPE(string cpeString)
        {
            // CPE String of the format cpe:2.3:part:vendor:product:ayaplcel.86a:update:edition:language:softwareEdition:targetSoftware:targetHardware:other
            string[] cpeParts = cpeString.Split(":");
            if (cpeParts.Length == 13)
            {
                Part = cpeParts[2];
                Vendor = cpeParts[3];
                Product = cpeParts[4];
                Version = cpeParts[5];
                Update = cpeParts[6];
                Edition = cpeParts[7];
                Language = cpeParts[8];
                SoftwareEdition = cpeParts[9];
                TargetSoftware = cpeParts[10];
                TargetHardware = cpeParts[11];
                Other = cpeParts[12];
            }
            else
            {
                throw new ArgumentException("CPE string has to be of the format \"cpe:2.3:part:vendor:product:ayaplcel.86a:update:edition:language:softwareEdition:targetSoftware:targetHardware:other\"");
            }

        }
        public string Part { get; set; }
        public string Vendor { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public string Update { get; set; }
        public string Edition { get; set; }
        public string Language { get; set; }
        public string SoftwareEdition { get; set; }
        public string TargetSoftware { get; set; }
        public string TargetHardware { get; set; }
        public string Other { get; set; }

        public override string ToString()
        {
            return $"cpe:2.3:{Part}:{Vendor}:{Product}:{Version}:{Update}:{Edition}:{Language}:{SoftwareEdition}:{TargetSoftware}:{TargetHardware}:{Other}";
        }

    }


    class CVE
    {
        public CVE(string id, List<CPE> affectedPrograms, DateTime publishTime, DateTime modifyTime, CVSS vulnerablityScore, CWE weaknessID, List<string> references, string summary)
        {
            ID = id;
            AffectedPrograms = affectedPrograms;
            PublishTime = publishTime;
            ModifyTime = modifyTime;
            VulnerabilityScore = vulnerablityScore;
            WeaknessID = weaknessID;
            References = references;
            Summary = summary;
        }

        public string ID { get; set; }
        public List<CPE> AffectedPrograms { get; set; }
        public DateTime PublishTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public CVSS VulnerabilityScore { get; set; }
        public CWE WeaknessID { get; set; }
        public List<string> References { get; set; }
        public string Summary { get; set; }
    }

    class CVSS
    {
        public float Score { get; set; }
        public string AccessVector { get; set; }
        public string AccessComplexity { get; set; }
        public string Authentication { get; set; }
        public string ConfidentialityImpact { get; set; }
        public string IntegrityImpact { get; set; }
        public string AvailabilityImpact { get; set; }
        public string Source { get; set; }
        public DateTime GenerationTime { get; set; }
    }

    class CWE
    {
        public int ID { get; set; }
    }
    [TestFixture]
    public class CPEModelTest
    {
        [Test]
        public static void GetStringCPEEqual()
        {
            var cpe = new CPE("cpe:2.3:o:intel:bios:bnkbl357.86a:*:*:*:*:*:*:*");
            string cpeString = cpe.ToString();
            cpeString = cpe.ToString();
            Assert.IsTrue(cpeString == "cpe:2.3:o:intel:bios:bnkbl357.86a:*:*:*:*:*:*:*");
        }
    }
}
