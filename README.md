# SEO Ranker

A React and .NET Core single page application to rank a url based on an online engine search for given keywords.

## Getting Started

### Requirements

- .NET Core 3.1
- React 16
- Reactstrap 6.3

### Build

1. Clone the repository `git clone https://github.com/jeffvhuang/seo-ranker`
2. The frontend should be run first since running on IIS depends on it (due to configuration for faster backend development): `cd SEORanker.presentation/ClientApp`, `npm i`, `npm start`
3. The quickest way to build and run the whole application (including backend) is to open in Visual Studio and run on IIS Express. Make sure SEORanker.presentation is set as the startup project.

### Notes on Design

Part of the app involves obtaining data from a Google Search. The data returned is html as a string, so in order to best navigate this data it needs to be parsed. There are a few ways to eventually parse the html to obtain the final results:

1. Use of HtmlAgilityPack package: This is a third party library.
2. Use HtmlDocument from System.Windows.Forms package. However this package is only available in .NET Framework.
3. Use regex and/or string search the entire response manually which is more likely to return errors and seemingly unnecessary when the data is clearly HTML.
4. Simply return to the entire string to the frontend since it is more capable of reading and navigating HTML DOM.

Currently the fourth option has been implemented.

## Authors

Jeffrey Huang (jeffvh@outlook.com)
