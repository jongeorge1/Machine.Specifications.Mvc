//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

using Machine.Specifications;

namespace Machine.Specifications.Mvc.Example
{
    using System.Web.Mvc;

    [Subject(typeof(PersonController))]
    public class context_for_a_person_controller
    {
        protected static PersonController personController;

        Establish context = () =>
        {
            personController = new PersonController();
        };
    }

    [Subject(typeof(PersonController))]
    public class when_the_person_controller_is_told_to_show_a_user : context_for_a_person_controller
    {
        static ActionResult result;

        Because of = () => result = personController.Show(1);

        It should_show_the_default_view = () =>
            result.ShouldBeAView().And().ShouldUseDefaultView();

        It should_show_the_correct_user_id_in_the_view = () =>
            result.ShouldBeAView().And().ShouldHaveModelOfType<Person>().And().Id.ShouldEqual(1);

        It should_show_the_correct_user_name_in_the_view = () =>
            result.Model<Person>().Name.ShouldEqual("James Broome"); // Shorter syntax for accessing model
    }

    [Subject(typeof(PersonController))]
    public class when_the_person_controller_is_told_to_show_a_user_that_does_not_exist : context_for_a_person_controller
    {
        static ActionResult result;

        Because of = () => result = personController.Show(999);

        It should_return_the_not_found_view = () =>
            result.ShouldBeAView().And().ViewName.ShouldEqual("NotFound");
    }

    [Subject(typeof(PersonController))]
    public class when_the_person_controller_is_told_to_update_a_person : context_for_a_person_controller
    {
        static ActionResult result;

        Because of = () => result = personController.Update(new Person(), true);

        It should_redirect_to_the_list_view = () =>
        {
            result.ShouldBeARedirectToRoute().And().ControllerName().ShouldEqual("Person");
            result.ShouldBeARedirectToRoute().And().ActionName().ShouldEqual("List");
        };
    }

    [Subject(typeof(PersonController))]
    public class when_the_person_controller_is_told_to_update_a_person_and_there_is_an_error : context_for_a_person_controller
    {
        static ActionResult result;

        Because of = () => result = personController.Update(new Person() { Id = 999 }, true);

        It should_redirect_to_the_update_view = () => result.ShouldRedirectToAction<PersonController>(x => x.Update());
    }

    [Subject(typeof(PersonController))]
    public class when_the_person_controller_is_told_to_update_a_person_and_the_user_is_not_authenticated : context_for_a_person_controller
    {
        static ActionResult result;

        Because of = () => result = personController.Update(new Person(), false);

        It should_redirect_to_the_open_id_url = () => 
            result.ShouldBeARedirect().And().Url.ShouldEqual("http://openid.co.uk");
    }
}