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
  ```
  < deploymentProvider codebase="https://raw.githubusercontent.com/RapiD-Engineering/RapiD.ClickOnceSample/master/Published/RapiD.ClickOnceSample.application/RapiD.ClickOnceSample.application"/>
  ```
  will become:
  ```
  < deploymentProvider codebase="https://raw.githubusercontent.com/RapiD-Engineering/RapiD.ClickOnceSample/master/Published/RapiD.ClickOnceSample.application" />
  ```
-Do this After each publish otherwise the install button on the page will do nothing



- After a succesfull publish, you can commit and push your new publish to github. (Select RapiD-Engineering as owner for your repo)
- in Github you need to create a Page in the Pages tab of your project setting.
- Select the branch and create the page
- Now we need to create the html file
- create a file install.html in the solution folder
copy this html to that file
```
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Install App</title>
    <style>
       
            
    </style>
    <script>


        function downloadClickOnce() {
            fetch('https://raw.githubusercontent.com/RapiD-Engineering/RapiD.ClickOnceSample/master/Published/RapiD.ClickOnceSample.application')
                .then(response => response.blob())
                .then(blob => {
                    const blobUrl = URL.createObjectURL(blob);
                    const a = document.createElement('a');
                    a.href = blobUrl;
                    a.download = 'RapiD.ClickOnceSample.application';
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                    URL.revokeObjectURL(blobUrl);
                })
                .catch(error => {
                    console.error("There was an error fetching the file:", error);
                });
    </script>
</head>
<body> 
    <h1>Install App</h1>
    <button onclick="downloadClickOnce()">Click here to Install</button>
</body>
</html>
```

- In the above file edit the fetch string to the string created in step 6
- Also edit the a.download string to your application 
- Push to github, this will create a job in github actions when done correctly.
- You can track the jobs progress in Github Actions and see when the page is deployed. 
- When the deplyment is done you can try isntalling via the link.
- https://[OWNER].github.io/[REPO]/install.html  (in this case:  https://RapiD-Engineering.github.io/RapiD.ClickOnceSample/install.html)



