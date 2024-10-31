// See https://aka.ms/new-console-template for more information
using ThingFormat.Properties;

Console.WriteLine("Hello, World!");

Analyst analyst = new Analyst();
Confidence confidence = new Confidence();
Presentation presentation = new Presentation();
ThingFormat.Properties.System system = new ThingFormat.Properties.System();

Properties properties;

properties = analyst;
properties.AddPoints(15);

properties = confidence;
properties.AddPoints(-10);

properties = analyst;
properties.AddPoints(15);

properties = confidence;
properties.AddPoints(5);