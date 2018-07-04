using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Toastmasters.Agenda.Entities;
using Toastmasters.Agenda.Extensions;

namespace Toastmasters.Web.Models
{
    public class ConfigViewModel
    {
        public ConfigViewModel() { }
        public ConfigViewModel(Config config)
        {
            Load(config);
        }

        [HiddenInput]
        public Single Verson { get; set; }

        #region Agenda Config

        public string MeetingTimeFormat { get; set; }
        public string AgendaTimeFormat { get; set; }
        public string MeetingDateFormat { get; set; }

        [Range(0, 60)]
        public int PresidingOfficerIntroMinutes { get; set; }
        [Range(0, 60)]
        public int ToastmasterIntroMinutes { get; set; }
        [Range(0, 60)]
        public int EvaluationTimeMinutes { get; set; }
        [Range(0, 60)]
        public int FunctionaryReportMinutes { get; set; }
        [Range(0, 60)]
        public int ListenerMinutes { get; set; }
        [Range(0, 60)]
        public int MentorMinutes { get; set; }
        [Range(0, 60)]
        public int MinClubBusinessMinutes { get; set; }

        [Range(0, 60)]
        public int MinTableTopicsMinutes { get; set; }
        [Range(0, 60)]
        public int MaxTableTopicsMinutes { get; set; }

        #endregion

        #region Club Config

        [Required]
        public string ClubName { get; set; }
        public string ClubNumber { get; set; }

        public DayOfWeek MeetingDayOfWeek { get; set; }

        [DataType(DataType.Time)]
        public DateTime MeetingStartTime { get; set; }

        [Range(10, 120)]
        public int MeetingLengthMinutes { get; set; }


        public string MeetingMessage { get; set; }

        [Url(ErrorMessage = "The Website URL must be a fully-qualified http or https address.")]
        public string WebsiteUrl { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string SlackChannel { get; set; }

        public string MissionStatement { get; set; }

        #endregion

        #region Officers Config

        public string PresidentName { get; set; }
        public string VPEducationName { get; set; }
        public string VPMembershipName { get; set; }
        public string VPPublicRelationsName { get; set; }
        public string SecretaryName { get; set; }
        public string TreasurerName { get; set; }
        public string SeargeantAtArmsName { get; set; }

        #endregion  

        private void Load(Config config)
        {
            this.Verson = config.Verson;

            // Agenda Config
            this.MeetingTimeFormat = config.AgendaConfig.MeetingTimeFormat;
            this.AgendaTimeFormat = config.AgendaConfig.AgendaTimeFormat;
            this.MeetingDateFormat = config.AgendaConfig.MeetingTimeFormat;

            this.PresidingOfficerIntroMinutes = config.AgendaConfig.PresidingOfficerIntroMinutes;
            this.ToastmasterIntroMinutes = config.AgendaConfig.ToastmasterIntroMinutes;
            this.EvaluationTimeMinutes = config.AgendaConfig.EvaluationTimeMinutes;
            this.FunctionaryReportMinutes = config.AgendaConfig.FunctionaryReportMinutes;
            this.ListenerMinutes = config.AgendaConfig.ListenerMinutes;
            this.MentorMinutes = config.AgendaConfig.MentorMinutes;

            this.MinClubBusinessMinutes = config.AgendaConfig.MinClubBusinessMinutes;

            this.MinTableTopicsMinutes = config.AgendaConfig.MinTableTopicsMinutes;
            this.MaxTableTopicsMinutes = config.AgendaConfig.MaxTableTopicsMinutes;

            // Club Config
            this.ClubName = config.ClubConfig.Name;
            this.ClubNumber = config.ClubConfig.Number;

            this.MeetingDayOfWeek = config.ClubConfig.MeetingDayOfWeek;
            this.MeetingStartTime = config.ClubConfig.MeetingStartTime.AsTime();
            this.MeetingLengthMinutes = config.ClubConfig.MeetingLengthMinutes;

            this.MeetingMessage = config.ClubConfig.MeetingMessage;

            this.WebsiteUrl = config.ClubConfig.WebsiteUrl;
            this.EmailAddress = config.ClubConfig.EmailAddress;
            this.SlackChannel = config.ClubConfig.SlackChannel;

            this.MissionStatement = config.ClubConfig.MissionStatement;

            // Officers Config
            this.PresidentName = config.ClubConfig.Officers.PresidentName;
            this.VPEducationName = config.ClubConfig.Officers.VPEducationName;
            this.VPMembershipName = config.ClubConfig.Officers.VPMembershipName;
            this.VPPublicRelationsName = config.ClubConfig.Officers.VPPublicRelationsName;
            this.SecretaryName = config.ClubConfig.Officers.SecretaryName;
            this.TreasurerName = config.ClubConfig.Officers.TreasurerName;
            this.SeargeantAtArmsName = config.ClubConfig.Officers.SeargeantAtArmsName;
        }

        public Config AsConfig()
        {
            return new Config()
            {
                AgendaConfig = new AgendaConfig()
                {
                    AgendaTimeFormat = this.AgendaTimeFormat,
                    EvaluationTimeMinutes = this.EvaluationTimeMinutes,
                    FunctionaryReportMinutes = this.FunctionaryReportMinutes,
                    ListenerMinutes = this.ListenerMinutes,
                    MaxTableTopicsMinutes = this.MaxTableTopicsMinutes,
                    MeetingDateFormat = this.MeetingDateFormat,
                    MeetingTimeFormat = this.MeetingTimeFormat,
                    MentorMinutes = this.MentorMinutes,
                    MinClubBusinessMinutes = this.MinClubBusinessMinutes,
                    MinTableTopicsMinutes = this.MinTableTopicsMinutes,
                    PresidingOfficerIntroMinutes = this.PresidingOfficerIntroMinutes,
                    ToastmasterIntroMinutes = this.ToastmasterIntroMinutes
                },
                ClubConfig = new Club()
                {
                    EmailAddress = this.EmailAddress,
                    MeetingDayOfWeek = this.MeetingDayOfWeek,
                    MeetingLengthMinutes = this.MeetingLengthMinutes,
                    MeetingMessage = this.MeetingMessage,
                    MeetingStartTime = this.MeetingStartTime.ToHours(),
                    MissionStatement = this.MissionStatement,
                    Name = this.ClubName,
                    Number = this.ClubNumber,
                    SlackChannel = this.SlackChannel,
                    WebsiteUrl = this.WebsiteUrl,
                    Officers = new Officers()
                    {
                        PresidentName = this.PresidentName,
                        VPEducationName = this.VPEducationName,
                        VPMembershipName = this.VPMembershipName,
                        VPPublicRelationsName = this.VPPublicRelationsName,
                        SecretaryName = this.SecretaryName,
                        TreasurerName = this.TreasurerName,
                        SeargeantAtArmsName = this.SeargeantAtArmsName
                    }
                },
                Verson = this.Verson
            };
        }
    }
}
