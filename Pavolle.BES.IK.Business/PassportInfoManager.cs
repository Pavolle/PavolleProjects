using Pavolle.BES.IK.Common.Enums;
using Pavolle.Core.Enums;
using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.BES.IK.Business
{
    public class PassportInfoManager : Singleton<PassportInfoManager>
    {
        private PassportInfoManager() { }

        public string GetPassportInfo(EPassportType passportType, ELanguage language)
        {
            switch (passportType)
            {
                case EPassportType.Service:
                    return "A service passport or grey passport is a type of passport issued to people who will work abroad for the state. It is very similar to the green passport issued to civil government officials. It can be given by special administrations and municipalities. National athletes also use these passports. In accordance with Passport Law No. 5682, it only covers the term of office. A grey passport allows visa-free entry to many countries. ";
                case EPassportType.Student:
                    return "A student passport is a travel document given to students planning to travel or study abroad. A student passport is issued to each student who meets the specified requirements. It is basically a maroon passport, but it is specially arranged for the students. ";
                case EPassportType.EPassport:
                    return "E-passport, electronic passport or biometric passport is the international travel document with identity details such as passport number, name, surname, nationality, and date of birth, as well as an electronic microprocessor chip containing data such as fingerprints, photos, and signatures. Biometric passports are scanned through special devices.\r\n\r\nE-passports, together with the codes developed, are much more effective against passport fraud than traditional passports.  E-passports, a new biometric passport containing all the information available in traditional passports, are designed to lighten the workload at passport checkpoints. Thanks to e-passports, the control system powered by the labor force is aimed to become an autonomous system in the future. ";
                case EPassportType.Requler:
                    return "A regular passport is a type of passport given to Turkish citizens who meet certain requirements. Regular passports are issued by the Department of Home Affairs, authorized governorships or Turkish consulates. It is also referred to as a maroon-colored passport due to its color. Regular passport holders can enter countries not requiring a visa directly bu using their passports. The regular passport has 38 pages and issued visas can be seen on these pages. Depending on the demand, the passport durations can cover a period of 6 months to 10 years. ";
                case EPassportType.Special:
                    return "A special passport is the type of passport issued to civil servants working on behalf of the state and their families for 5 years as long as they meet certain requirements. It is also called a green passport as it is green. A special passport has many privileges. It provides visa-free entry to many countries limited to the number of days.";
                case EPassportType.Diplomatic:
                    return "Diplomatic passport; is a type of international identity document issued by the Ministry of Foreign Affairs defining the positions of diplomats and grants them privileges. Diplomatic passports are issued to government officials and their families who have been sent abroad to attend congresses and conferences. It is black, has 28 pages and is exempt from any fees.";
                case EPassportType.Temporary:
                    return "A temporary passport or a pink passport is a travel document that Turkish citizens abroad can obtain from Turkish foreign representative offices (consulates). Temporary passports are valid only for 1 month in cases such as passport loss, passport expiration, and deportation. In similar emergency cases, a temporary passport can be issued according to the assessment to be made by the Turkish embassy. It is colored pink with only one page and will be taken away from you as soon as you enter Turkey.";
                case EPassportType.Baby:
                    return "A baby passport is a travel document used for foreign journeys requiring a passport, even if one day has passed since birth. This type of passport, also called a child passport, is no different from an adult passport.";
                case EPassportType.Pet:
                    return "The Pet passport is not only a travel document that you need in order to bring your pet abroad with you but also an identification for animals such as cats, dogs, and weasels. If you plan to go to an EU country or Northern Ireland with your pet, you must get a \"passport\" or an “animal health certificate” for your pet, as well as having \"microchip\" operations performed. Additionally, if you're taking your dog directly to Finland, Ireland, Northern Ireland, Norway, or Malta, tapeworm treatment is required.\r\n\r\nYou must get an export health certificate if you are travelling to a non-EU nation (EHC). If you reside in England, Scotland, or Wales, an export application form (EXA) must also be completed. An EHC verifies that your pet meets the country's health regulations before you depart.";
                default:
                    return "";
            }
        }

    }
}
