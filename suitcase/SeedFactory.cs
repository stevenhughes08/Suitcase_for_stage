using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using suitcase.Data;
using suitcase.Models;


namespace suitcase
{
    public class SeedFactory
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            if (!context.Set<Prop>().Any())
            {
                var props = new List<Prop>()
                {
                    new Prop
                    {
                        Name = "Table",
                        StorageLocation = "Basement"
                    },
                    new Prop
                    {
                        Name = "Logo Suitcase",
                        StorageLocation = "Basement"
                    },
                    new Prop
                    {
                        Name = "Simcha's Pants",
                        StorageLocation = "Logo Suitcase"
                    },
                    new Prop
                    {
                        Name = "Folding Chairs",
                        StorageLocation = "Basement"
                    },
                    new Prop
                    {
                        Name = "Bubble-ishus' Purse",
                        StorageLocation = "Logo Suitcase"
                    },
                   new Prop
                    {
                        Name = "Table",
                        StorageLocation = "Basement"
                    },
                    new Prop
                    {
                        Name = "50 Shades of Clown Book",
                        StorageLocation = "Bubble-ishus' Purse"
                    },
                    new Prop
                    {
                        Name = "Newspaper",
                        StorageLocation = "Drawer 3"
                    },
                    new Prop
                    {
                        Name = "Newspaper Airplane",
                        StorageLocation = "Drawer 3"
                    },
                    new Prop
                    {
                        Name = "Playing Cards",
                        StorageLocation = "Drawer 3"
                    },
                    new Prop
                    {
                        Name = "Bunny Suit",
                        StorageLocation = "Rack 1"
                    },
                    new Prop
                    {
                        Name = "Vodka Bottles 6 pack",
                        StorageLocation = "Basement"
                    },
                    new Prop
                    {
                        Name = "Shot Glasses",
                        StorageLocation = "Drawer 3"
                    },

                    new Prop
                    {
                        Name = "Bench",
                        StorageLocation = "Basement Next to costume shelves"
                    },
                     new Prop
                    {
                        Name = "Salty's Silver Purse",
                        StorageLocation = "Rack 1"
                    },
                    new Prop
                    {
                        Name = "Sun Visors Qty 2",
                        StorageLocation = "Drawer 4"
                    }, 
                     new Prop
                    {
                        Name = "1 leged stool",
                        StorageLocation = "Behind Prop Drawers"
                    }

                };
                context.AddRangeAsync(props);
                context.SaveChangesAsync(); 
            };

            context.Database.EnsureCreated();
            if(!context.Set<Act>().Any())
            {       
                var acts = new List<Act>()
                {
                        new Act
                        {
                            Name = "Bus Stop",
                            Performance = "Everything in Life is Luck"
                        },
                        new Act
                        {
                            Name = "Poker",
                            Performance = "Stuck in New Albany...again"
                        },
                        new Act
                        {
                            Name = "Bottle Act",
                            Performance = "Greatest Hits"
                        },
                        new Act
                        {
                            Name = "Tinder",
                            Performance = "Greatest Hits"
                        }, 
                        new Act
                        {
                            Name = "Helium",
                            Performance = "Greatest Hits"
                        },
                        new Act
                        {
                            Name = "Beach Act",
                            Performance = "Vodka-Rama"
                        }
                    };
                    
                context.AddRangeAsync(acts);
                context.SaveChangesAsync(); 
    
            }

            context.Database.EnsureCreated();
            if(!context.Set<Performance>().Any())
            {       
                var performances = new List<Performance>()
                {
                    new Performance
                    {
                        Name = "Shotglass Fairy Tales"
                    },
                    new Performance
                    {
                        Name = "Vodka-Rama"
                    },
                      new Performance
                    {
                        Name = "Imaginarium: Writer's Block"
                    },
                      new Performance
                    {
                        Name = "Easter Riot!"
                    },
                      new Performance
                    {
                        Name = "Birthday Show"
                    },
                    new Performance
                    {
                        Name = "Imaginarium Magic Cabaret"
                    }

                };

                context.AddRangeAsync(performances);
                context.SaveChangesAsync(); 
            }

            context.Database.EnsureCreated();
            if(!context.Set<Performer>().Any())
            {       
                 var performers = new List<Performer>()
                {
                    new Performer
                    {
                        Name = "Bubble-ishus",
                        HeadShotUrl = "./bubbleishus.jpg"
                    },
                    new Performer
                    {
                        Name = "Katya",
                        HeadShotUrl = "./katya.jpg"
                    },
                    new Performer
                    {
                        Name = "Salty",
                        HeadShotUrl = "./salty.jpg"
                    },
                     new Performer
                    {
                        Name = "Simcha",
                        HeadShotUrl = "./simcha.jpg"
                    },
                    new Performer
                    {
                        Name = "Svengali",
                        HeadShotUrl = "./svegali.jpg"
                    }  
                };

              context.AddRangeAsync(performers);
              context.SaveChangesAsync(); 
            }
        }
    }
}