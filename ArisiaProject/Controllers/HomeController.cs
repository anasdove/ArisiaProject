using System;
using System.Net;
using System.Web.Mvc;
using ArisiaProject.Domain;
using ArisiaProject.Repositories;

namespace ArisiaProject.Controllers
{
    public class HomeController : Controller
    {
        #region Declarations

        IMemberRepository memberRepository = new MemberRepository();

        #endregion

        #region MVC Method

        public ActionResult Index()
        {
            //memberRepository.Add(AddMember());

            return View(new Member());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(Member member)
        {
            memberRepository.Add(member);
            return View(member);
        }

        #endregion

        #region Private Method

        private static Member AddMember()
        {
            return new Member
            {
                Address = new Address
                {
                    PostCode = "65147",
                    State = "East Java",
                    StreetAddress = "Jl Terusan Mergan Raya 31 Malang"
                },
                BirthOfDate = new DateTime(1989, 5, 17),
                Grade = "AP",
                Name = "Choirul Anas"
            };
        }

        #endregion
    }
}
