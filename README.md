# ToastmastersAgenda

## A C#/.NET Core project for generating agenda's for Toastmasters meetings.

Our Toastmasters club was getting tired of manually editing word documents every week
to create our agendas. The process was very error-prone and required each Toastmaster
to manually figure-out the timings for the meeting.

This project seeks to simplify and standardize the process by creating a website that
a toastmaster can use to generate their agenda. Timings are automatically modified
to handle single vs. multiple speeches, as well as variations in other activities.

We started by satisfying the needs of our club, but we want to make
this available as simply as possible for everyone to use. As a result, we want to 
avoid logins if possible and having to store any data on the server.  We have 
accomplished this by storing all user data in browser cookies. Thus, any 
configuration added by the user is unique to that user and not shared. Config
files can be downloaded and shared among club members, but each member will
have to upload the configuration file once prior to use.  This also means that
we do not store any personally identifiable information and do not track users
in any way (other than standard web server logs) so there are no GDPR or 
other privacy issues to be concerned about.

It should be noted that there is at least one other agenda builder 
for Toastmasters out there, but it required the club to host the club 
website under their hosting umbrella, which didn't work for us. If you 
also need a place to host your club website, FreeToastHost or some equivalent
may be a better choice for your club.

## Project Structure

### Common library
The *.Net Standard 2.0* library found at **/src/Toastmasters.Agenda/** holds the common elements 
of the project.  This includes Builders, Entities, Extension Methods & Interfaces
that are used in other projects.

### Agenda Generator
The *.Net Standard 2.0* library found at **/src/Toastmasters.Agenda.Generator.Html/** holds an
implementation of the *Toastmasters.Agenda.Interfaces.IAgendaGenerator* interface. This implementation
creates the agenda in an HTML5 compliant document.  The document is completely self contained. That is, 
all style, content and images are stored inside the file so that it can easily be passed around, simply
by sending the resulting file to another user.

### Website
The project website can be found under **src/Toastmasters.Web**. It is an ASP.NET Core MVC 2.0 site 
that collects the required data and then utilizes the *Toastmasters.Agenda.Generator.Html.Engine* 
to generate and present the agenda.  This project also allows the user to modify configuration information
to be stored in the user's web browser.

### Tools
There are currently 2 tools projects in the repository:

1) Agenda - A .NET Core executable that can generate agendas locally using the 
specified *IAgendaGenerator* implementation. This is mostly used for local testing.

1) CreateConfig - A .NET Core executable that can generate configuration files locally.
This should not be needed once the configuration aspects of the website have been built.

## Feature Requests

Please feel free to add your feature requests to 
the [Issues Page](https://github.com/bsstahl/ToastmastersAgenda/issues). 
We'll do what we can to make this valuable for all Toastmasters clubs.