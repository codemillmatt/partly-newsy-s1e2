# Partly Cloudy Episode 2: Inform Me (Bing News API)

Welcome back to Partly Cloudy! The show where you learn how to build a cloud-connected Xamarin mobile application. We start from nothing and don't quit until it's ready for the App Store!

![partly cloudy drawing](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:77,h_600/v1571800204/PNG_image-E7EAA277EA90-1_tlmaz2.png)

The app we're building is a clone of the Microsoft News app.

In [episode 1](https://devblogs.microsoft.com/xamarin/partly-cloudy?WT.mc_id=mobile-0000-masoucou), we set the project up and got it to communicate to an Azure Function (running locally!)

But somehow we're going to need to get the news. And that's what this episode is all about, getting the news from the [Bing News Search API](https://docs.microsoft.com/azure/cognitive-services/Bing-News-Search/?WT.mc_id=mobile-0000-masoucou).

You're gonna need some Azure for this episode, so [get some free Azure here](https://azure.microsoft.com/free?WT.mc_id=mobile-0000-masoucou)!

## Episode Recap

This episode found us in the cloud the entire time. We created a Bing News Search Cognitive Service. Added that cog service to our Azure Function from the last episode. Then brought down the news to our mobile app.

Easy enough. But let's go over some things to make sure you get your code up and running as quick and smooth as possible. 

## Getting the News

Our app gets the news from the Bing News Search Cognitive Service. This cognitive service can do quite a lot! It can return the news by a search term. It can return today's top news. It can even return news trending on social networks.

> To find out more about Bing News Search - check out [this Pluralsight course](https://app.pluralsight.com/library/courses/microsoft-cognitive-services-bing-news-search).

In the episode, I demonstrated how to create the News Search service with the Azure Command Line Interface.

## Call Bing News From Azure Functions

In the episode, we made it a point to not call out to Bing News Search from the mobile application. Rather, call it from Azure Functions.

Why?

The most important reason is to ensure the Bing News Search API key does not get compromised. By having the API key on the server, there's less of a chance of that happening. (And to be super safe, [lock that key in KeyVault](https://docs.microsoft.com/azure/key-vault/?WT.mc_id=mobile-0000-masoucou). Follow this [article for more info](https://codemilltech.com/mobile-apps-azure-keyvault-dont-do-it/)!)

The other reason is that having the Bing News Search logic in a Function is because that logic will be in a single spot. This means we can tailor the logic for our applications all-up. Be they mobile, web, or whatever. And that custom logic means we can tailor the results to best fit our applications.

And ... things are easy to refactor when all the logic is in one spot too!

### Getting Your Functions To Call Bing News API

The changes that you need to do to your Function app are as follows:

1.  Make your Article.cs class look like the following:

<script src="https://gist.github.com/codemillmatt/d24c67005f26a9a4f8757deca0c04386.js"></script>

2.  Add `NewsSearchApiKey` and `NewsSearchUrl` to your `local.settings.json` file - it should look like this:

<script src="https://gist.github.com/codemillmatt/828ace7089a93fccd0ac4012e006d9a4.js"></script>


3.  Then run out to the portal to grab the values for each. `NewsSearchApiKey` is found on the Keys tab.

![key screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/bo_0px_solid_rgb:ffffff,c_scale,e_shadow:40,h_600/v1571796277/Screen_Shot_2019-10-22_at_6.43.28_PM_xdylrl.png)

4.  `NewsSearchUrl` is on the overview tab.

![url screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_600/v1571796246/Screen_Shot_2019-10-22_at_6.43.10_PM_rsrfgr.png)

Pop those together and you should be good to go. If not, take a look at the code to help you through it.

## The Mobile App

All the good stuff happened in the cloud. Not much needs to change in the mobile app.

What does need to change though is in the `NewsService`.

Make sure you're returning a `List<Article>` from the `INewsFunctionAPI`. And in the UI - you can swap in a `ListView` to display everything.

## That's It!

There you have it! Our app is now connected and getting the news! The Azure Function is taking care of all the work, with a lot of help from Bing News Search!

In the next episode - we're going to be adding some UI magic to make things look sweet!
