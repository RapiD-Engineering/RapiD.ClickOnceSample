# RapiD.ClickOnceSample
Sample for publishing with ClickOnce

This is a sample project to publish and automatically serve updates for .NET application using ClickOnce. This sample will only work for public repositories.

To publish an application:

- Create a Folder called 'Published' in your solution directory (not in project directory)
- Right click on your project and click Publish
- Select ClickOnce
- For the publish location select the folder created in step 1
- Select 'From a Website' in the install location selection
- Install Location is the following string  https://raw.githubusercontent.com/[GITHUBACCOUNTOWNER]/[PROJECTNAME]/[BRANCH]/Published/[PROJECTNAME].application/
- Update settings location is the same string as above
- Version will increment automatically on each publish
- Specify your configuration (leave 'Produce Single File' unchecked)
- Finish and try to publish

- In the Published/[ProjectName].application file we need to edit a string for it to work correctly, open this file in a text-editor.
  remove the duplicate application path at the end of the codebase string so
   this:
  deploymentProvider codebase="https://raw.githubusercontent.com/RapiD-Engineering/RapiD.ClickOnceSample/master/Published/RapiD.ClickOnceSample.application/RapiD.ClickOnceSample.application" 
  will become:
  deploymentProvider codebase="https://raw.githubusercontent.com/RapiD-Engineering/RapiD.ClickOnceSample/master/Published/RapiD.ClickOnceSample.application" 

- After a succesfull publish, you can commit and push your new publish to github.

