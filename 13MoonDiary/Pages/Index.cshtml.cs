using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _13MoonDiary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public static List<MayanOracle> MayanOracles { get; set; }

        [BindProperty]
        public static List<Tone> tones { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            InitOracle();
            var todayOracle = MayanOracles[5];
            DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
        }

        public void InitOracle()
        {
            List<MayanOracle> oracles = new List<MayanOracle>
            {
                new MayanOracle
                {
                    id=1,
                    oracleEName="Dragon",
                    oracleName="紅龍",
                    oracleColor="Red",
                    oracleImgSrc="01-mayankin-marielamaya-bridgingworlds-tzolkin-red-dragon-glyph.png"
                },
                new MayanOracle
                {
                    id=2,
                    oracleEName="Wind",
                    oracleName="白風",
                    oracleColor="White",
                    oracleImgSrc="02-mayankin-marielamaya-bridgingworlds-tzolkin-white-wind-glyph.png"
                },
                new MayanOracle
                {
                    id=3,
                    oracleEName="Night",
                    oracleName="藍夜",
                    oracleColor="Blue",
                    oracleImgSrc="03-mayankin-marielamaya-bridgingworlds-tzolkin-blue-night-glyph.png"
                },
                new MayanOracle
                {
                    id=4,
                    oracleEName="Seed",
                    oracleName="黃種子",
                    oracleColor="Yellow",
                    oracleImgSrc="04-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-seed-glyph.png"
                },
                new MayanOracle
                {
                    id=5,
                    oracleEName="Serpent",
                    oracleName="紅蛇",
                    oracleColor="Red",
                    oracleImgSrc="05-mayankin-marielamaya-bridgingworlds-tzolkin-red-serpent-glyph.png"
                },
                new MayanOracle
                {
                    id=6,
                    oracleEName="WorldBridger",
                    oracleName="白世界橋",
                    oracleColor="White",
                    oracleImgSrc="06-mayankin-marielamaya-bridgingworlds-tzolkin-white-world-bridger-glyph.png"
                },
                new MayanOracle
                {
                    id=7,
                    oracleEName="Hand",
                    oracleName="藍手",
                    oracleColor="Blue",
                    oracleImgSrc="07-mayankin-marielamaya-bridgingworlds-tzolkin-blue-hand-glyph.png"
                },
                new MayanOracle
                {
                    id=8,
                    oracleEName="Star",
                    oracleName="黃星星",
                    oracleColor="Yellow",
                    oracleImgSrc="08-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-star-glyph.png"
                },
                new MayanOracle
                {
                    id=9,
                    oracleEName="Moon",
                    oracleName="紅月",
                    oracleColor="Red",
                    oracleImgSrc="09-mayankin-marielamaya-bridgingworlds-tzolkin-red-moon-glyph.png"
                },
                new MayanOracle
                {
                    id=10,
                    oracleEName="Dog",
                    oracleName="白狗",
                    oracleColor="White",
                    oracleImgSrc="10-mayankin-marielamaya-bridgingworlds-tzolkin-white-dog-glyph.png"
                },
                new MayanOracle
                {
                    id=11,
                    oracleEName="Monkey",
                    oracleName="藍猴",
                    oracleColor="Blue",
                    oracleImgSrc="11-mayankin-marielamaya-bridgingworlds-tzolkin-blue-monkey-glyph.png"
                },
                new MayanOracle
                {
                    id=12,
                    oracleEName="Human",
                    oracleName="黃人",
                    oracleColor="Yellow",
                    oracleImgSrc="12-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-human-glyph.png"
                },
                new MayanOracle
                {
                    id=13,
                    oracleEName="SkyWalker",
                    oracleName="紅天行者",
                    oracleColor="Red",
                    oracleImgSrc="13-mayankin-marielamaya-bridgingworlds-tzolkin-red-skywalker-glyph.png"
                },
                new MayanOracle
                {
                    id=14,
                    oracleEName="Wizard",
                    oracleName="白巫師",
                    oracleColor="White",
                    oracleImgSrc="14-mayankin-marielamaya-bridgingworlds-tzolkin-white-wizard-glyph.png"
                },
                new MayanOracle
                {
                    id=15,
                    oracleEName="Eagle",
                    oracleName="藍鷹",
                    oracleColor="Blue",
                    oracleImgSrc="15-mayankin-marielamaya-bridgingworlds-tzolkin-blue-eagle-glyph.png"
                },
                new MayanOracle
                {
                    id=16,
                    oracleEName="Warrior",
                    oracleName="黃戰士",
                    oracleColor="Yellow",
                    oracleImgSrc="16-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-warrior-glyph.png"
                },
                new MayanOracle
                {
                    id=17,
                    oracleEName="Earth",
                    oracleName="紅地球",
                    oracleColor="Red",
                    oracleImgSrc="17-mayankin-marielamaya-bridgingworlds-tzolkin-red-earth-glyph.png"
                },
                new MayanOracle
                {
                    id=18,
                    oracleEName="Mirror",
                    oracleName="白鏡",
                    oracleColor="White",
                    oracleImgSrc="18-mayankin-marielamaya-bridgingworlds-tzolkin-white-mirror-glyph.png"
                },
                new MayanOracle
                {
                    id=19,
                    oracleEName="Storm",
                    oracleName="藍風暴",
                    oracleColor="Blue",
                    oracleImgSrc="19-mayankin-marielamaya-bridgingworlds-tzolkin-blue-storm-glyph.png"
                },
                new MayanOracle
                {
                    id=20,
                    oracleEName="Sun",
                    oracleName="黃太陽",
                    oracleColor="Yellow",
                    oracleImgSrc="20-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-sun-glyph.png"
                }

            };

            MayanOracles = oracles;
        }
        public void InitTone()
        {
            List<Tone> tones = new List<Tone>
            {
                new Tone
                {
                    id=1,
                    toneEName = "Magnetic",
                    toneName = "磁性",
                    toneImgSrc = ""
                }
            };
        }
    }

    public class MayanOracle
    {
        public int id;
        public string oracleEName;
        public string oracleName;
        public string oracleColor;
        public string oracleImgSrc;

        public MayanOracle()
        {
        }

        public MayanOracle(int id,  string oracleEName, string oracleName, string oracleColor, string oracleImgSrc)
        {
            this.id = id;
            this.oracleEName = oracleEName;
            this.oracleName = oracleName;
            this.oracleColor = oracleColor;
            this.oracleImgSrc = oracleImgSrc;
        }
    }

    public class Tone
    {
        public int id;
        public string toneEName;
        public string toneName;
        public string toneImgSrc;

        public Tone()
        {
        }

        public Tone(int id, string toneEName, string toneName, string toneImgSrc)
        {
            this.id = id;
            this.toneEName = toneEName;
            this.toneName = toneName;
            this.toneImgSrc = toneImgSrc;
        }
    }

    public class CardInfo
    {
        public DateTime date;
        public string weekDay;
        public int mainoracleEName;

    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }

}
