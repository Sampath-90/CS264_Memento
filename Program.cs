/*
Name: Saisampath Adusumilli
Student Number: 20251888
Memento Design
*/
using System;
using System.Text;
namespace Program{
  public class Program{
    static void Main(string [] args){
      FeatureFactory featureFactory = new FeatureFactory();
      var final_output1 = new Dictionary<string,string>();
      var temp_dict = new Dictionary<string,string>();
      Caretaker caretaker = new Caretaker();
      Originator originator = new Originator();

      string ? output_file = ""; 
      StringBuilder svg_text = new StringBuilder();
      string svg_header = "<svg height=\"250\" width=\"250\"  xmlns=\"http://www.w3.org/2000/svg\" >" +
        Environment.NewLine + "".PadLeft(3,' ') +"<circle cx=\"128\" cy=\"128\" r=\"120\" stroke=\"black\" stroke-width=\"3\" fill=\"yellow\" />";
      svg_text.Append(svg_header);

      //command list
      Console.WriteLine("Commands:" + Environment.NewLine +
                                                "add\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                                "remove\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                                "move\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {up| down| left| right} value" + Environment.NewLine +
                                                "rotate\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {clockwise| anticlockwise} degrees" + Environment.NewLine +
                                                "style\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {A|B|C}" + Environment.NewLine +
                                                "save\t\t {<file>}" + Environment.NewLine +
                                                "draw" + Environment.NewLine+
                                                "undo" + Environment.NewLine+
                                                "redo" + Environment.NewLine+
                                                "help" + Environment.NewLine+
                                                "quit");

       string input = "";
       do{
        input = Console.ReadLine()!.ToLower();
        switch(input.Split(" ")[0]){
          case "add": Add_feature(input.Split(" ")[1]);break;
          case "remove": Remove_feature(input.Split(" ")[1]);break;
          case "move": Move_feature(input.Split(" ")[1],input.Split(" ")[2],Int32.Parse(input.Split(" ")[3]));break;
          case "style": Style_feature(input.Split(" ")[1],input.Split(" ")[2].ToUpper());break;
          case "rotate": Rotate_feature(input.Split(" ")[1],input.Split(" ")[2],Int32.Parse(input.Split(" ")[3]));break;
          case "undo": {if(final_output1.Count == 0){Console.WriteLine("Cannot Undo!");}
                     else{Undo_feature(caretaker,originator);temp_dict.Add(final_output1.Keys.Last(),final_output1.Values.Last());final_output1.Remove(final_output1.Keys.Last());}}
          break;
          case "redo": if(temp_dict.Count == 0){Console.WriteLine("Cannot Redo!");}
                else{Redo_feature(caretaker,originator);final_output1.Add(temp_dict.Keys.Last(),temp_dict.Values.Last());temp_dict.Remove(final_output1.Keys.Last());}
                break;
          case "help":{
                  Console.WriteLine("Commands:" + Environment.NewLine +
                                    "add\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                    "remove\t\t {left-eye| right-eye| left-brow| right-brow| mouth}" + Environment.NewLine +
                                    "move\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {up| down| left| right} value" + Environment.NewLine +
                                    "rotate\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {clockwise| anticlockwise} degrees" + Environment.NewLine +
                                    "style\t\t {left-eye| right-eye| left-brow| right-brow| mouth} {A|B|C}" + Environment.NewLine +
                                    "save\t\t {<file>}" + Environment.NewLine +
                                    "draw" + Environment.NewLine+
                                    "undo" + Environment.NewLine+
                                    "redo" + Environment.NewLine+
                                    "help" + Environment.NewLine+
                                    "quit");break;                  
                }
          case "save":{output_file = input.Split(" ")[1];
                Console.WriteLine("Emoticon saved to file: " + output_file);break;} 
          case "draw": {Draw_feature();break;}            
          case "quit":{if(output_file!.Length == 0){Console.WriteLine("Enter the name of the file to save:");output_file = Console.ReadLine();}
                Console.WriteLine("Exiting Application");break;}
           default: Console.WriteLine("Please enter a valid command");break;
        }
       }while(!(input.Equals("quit"))); 

       void Add_feature(string a){
          switch(a){
            case "left-eye":{
              if(final_output1.ContainsKey("left-eye")){
                Console.WriteLine("Already added, can't add again!");
                break;
              }
              Feature feature = featureFactory.GetFeature("left-eye");
              final_output1.Add("left-eye",feature.printFeatureA());
              Console.WriteLine("Left-Eye added to emoticon");
              originator.setState("Left-Eye added to emoticon");
              //sets the current state to the feature created
              caretaker.add(originator.saveStateToMemento());
              //adds the current feature to the undo list in Caretaker class
              break;
            }
            case "right-eye":{
              if(final_output1.ContainsKey("right-eye")){
                Console.WriteLine("Already added, can't add again!");
                break;
              }
              Feature feature = featureFactory.GetFeature("right-eye");
              final_output1.Add("right-eye",feature.printFeatureA());
              Console.WriteLine("Right-Eye added to emoticon");
              originator.setState("Right-Eye added to emoticon");
              //sets the current state to the feature created
              caretaker.add(originator.saveStateToMemento());
              //adds the current feature to the undo list in Caretaker class
              break;
            }
            case "left-brow":{
              if(final_output1.ContainsKey("left-brow")){
                Console.WriteLine("Already added, can't add again!");
                break;
              }
              Feature feature = featureFactory.GetFeature("left-brow");
              final_output1.Add("left-brow",feature.printFeatureA());
              Console.WriteLine("Left-Brow added to emoticon");
              originator.setState("Left-Brow added to emoticon");
              //sets the current state to the feature created
              caretaker.add(originator.saveStateToMemento());
              //adds the current feature to the undo list in Caretaker class
              break;
            }
            case "right-brow":{
              if(final_output1.ContainsKey("right-brow")){
                Console.WriteLine("Already added, can't add again!");
                break;
              }
              Feature feature = featureFactory.GetFeature("right-brow");
              final_output1.Add("right-brow",feature.printFeatureA());
              Console.WriteLine("Left-Eye added to emoticon");
              originator.setState("Left-Eye added to emoticon");
              //sets the current state to the feature created
              caretaker.add(originator.saveStateToMemento());
              //adds the current feature to the undo list in Caretaker class
              break;
            }
            case "mouth":{
              if(final_output1.ContainsKey("mouth")){
                Console.WriteLine("Already added, can't add again!");
                break;
              }
              Feature feature = featureFactory.GetFeature("mouth");
              final_output1.Add("mouth",feature.printFeatureA());
              Console.WriteLine("Mouth added to emoticon");
              originator.setState("Mouth added to emoticon");
              //sets the current state to the feature created
              caretaker.add(originator.saveStateToMemento());
              //adds the current feature to the undo list in Caretaker class
              break;
            }
            default: Console.WriteLine("Please enter a valid feature");break;
          }
       }

       //remove features
       void Remove_feature(string a){
        if(final_output1.ContainsKey(a)){
          switch(a){
          case "left-eye":{
                    temp_dict.Add("left-eye",final_output1["left-eye"]);
                    Console.WriteLine("Left-Eye removed from emoticon");
                    originator.setState("Left-Eye removed from emoticon");
                    caretaker.add(originator.saveStateToMemento());
                    final_output1.Remove("left-eye");
                    break;
          }
          case "right-eye":{
                    temp_dict.Add("right-eye",final_output1["right-eye"]);
                    Console.WriteLine("Right-Eye removed from emoticon");
                    originator.setState("Right-Eye removed from emoticon");
                    caretaker.add(originator.saveStateToMemento());
                    final_output1.Remove("right-eye");
                    break;
          }
          case "left-brow":{
                    temp_dict.Add("left-brow",final_output1["left-brow"]);
                    Console.WriteLine("Left-Brow removed from emoticon");
                    originator.setState("Left-Brow removed from emoticon");
                    caretaker.add(originator.saveStateToMemento());
                    final_output1.Remove("left-brow");
                    break;
          }
          case "right-brow":{
                    temp_dict.Add("right-brow",final_output1["right-brow"]);
                    Console.WriteLine("Right-Brow removed from emoticon");
                    originator.setState("Right-Brow removed from emoticon");
                    caretaker.add(originator.saveStateToMemento());
                    final_output1.Remove("Right-brow");
                    break;
          }
          case "mouth":{
                    temp_dict.Add("mouth",final_output1["mouth"]);
                    Console.WriteLine("Mouth removed from emoticon");
                    originator.setState("Mouth removed from emoticon");
                    caretaker.add(originator.saveStateToMemento());
                    final_output1.Remove("mouth");
                    break;
          }
          default: Console.WriteLine("Please enter a valid feature");break;
         }
        }
        else
          Console.WriteLine("Cannot remove as the feature is not added");
       }
      
      //styling
      void Style_feature(string a, string b){
         if(final_output1.ContainsKey(a)){ //checking if the feature is created or not
          switch(a){
          case "left-eye":{
            Feature feature = featureFactory.GetFeature("left-eye");
            temp_dict.Add("left-eye",final_output1["left-eye"]);
            switch(b){
              case "A":{final_output1.Remove("left-eye");
                final_output1.Add("left-eye",feature.printFeatureA());
                Console.WriteLine("Left-Eye to style A");
                originator.setState("Left-Eye to style A");
                caretaker.add(originator.saveStateToMemento());
                break;}
              case "B":{final_output1.Remove("left-eye");
                final_output1.Add("left-eye",feature.printFeatureB());
                Console.WriteLine("Left-Eye to style B");
                originator.setState("Left-Eye to style B");
                caretaker.add(originator.saveStateToMemento());break;}
              case "C":{final_output1.Remove("left-eye");
                final_output1.Add("left-eye",feature.printFeatureC());
                Console.WriteLine("Left-Eye to style C");
                originator.setState("Left-Eye to style C");
                caretaker.add(originator.saveStateToMemento());break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }
            break;
          }
          case "right-eye":{
            Feature feature = featureFactory.GetFeature("right-eye");
            temp_dict.Add("right-eye",final_output1["right-eye"]);
            switch(b){
              case "A":{final_output1.Remove("right-eye");
                final_output1.Add("right-eye",feature.printFeatureA());
                Console.WriteLine("Right-Eye to style A");
                originator.setState("Right-Eye to style A");
                caretaker.add(originator.saveStateToMemento());
                break;}
              case "B":{final_output1.Remove("right-eye");
                final_output1.Add("right-eye",feature.printFeatureB());
                Console.WriteLine("Right-Eye to style B");
                originator.setState("Right-Eye to style B");
                caretaker.add(originator.saveStateToMemento());break;}
              case "C":{final_output1.Remove("right-eye");
                final_output1.Add("right-eye",feature.printFeatureC());
                Console.WriteLine("Right-Eye to style C");
                originator.setState("Right-Eye to style C");
                caretaker.add(originator.saveStateToMemento());break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }
            break;
          }
          case "left-brow":{
            Feature feature = featureFactory.GetFeature("left-brow");
            temp_dict.Add("left-brow",final_output1["left-brow"]);
            switch(b){
              case "A":{final_output1.Remove("left-brow");
                final_output1.Add("left-brow",feature.printFeatureA());
                Console.WriteLine("Left-Brow to style A");
                originator.setState("Left-Brow to style A");
                caretaker.add(originator.saveStateToMemento());
                break;}
              case "B":{final_output1.Remove("left-brow");
                final_output1.Add("left-brow",feature.printFeatureB());
                Console.WriteLine("Left-Brow to style B");
                originator.setState("Left-Brow to style B");
                caretaker.add(originator.saveStateToMemento());break;}
              case "C":{final_output1.Remove("left-brow");
                final_output1.Add("left-brow",feature.printFeatureC());
                Console.WriteLine("Left-Brow to style C");
                originator.setState("Left-Brow to style C");
                caretaker.add(originator.saveStateToMemento());break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }
            break;
          }
          case "right-brow":{
            Feature feature = featureFactory.GetFeature("right-brow");
            temp_dict.Add("right-brow",final_output1["right-brow"]);
            switch(b){
              case "A":{final_output1.Remove("right-brow");
                final_output1.Add("right-brow",feature.printFeatureA());
                Console.WriteLine("Right-Brow to style A");
                originator.setState("Right-Brow to style A");
                caretaker.add(originator.saveStateToMemento());
                break;}
              case "B":{final_output1.Remove("right-brow");
                final_output1.Add("right-brow",feature.printFeatureB());
                Console.WriteLine("Right-Brow to style B");
                originator.setState("Right-Brow to style B");
                caretaker.add(originator.saveStateToMemento());break;}
              case "C":{final_output1.Remove("right-brow");
                final_output1.Add("right-brow",feature.printFeatureC());
                Console.WriteLine("Right-Brow to style C");
                originator.setState("Right-Brow to style C");
                caretaker.add(originator.saveStateToMemento());break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }
            break;
          }
          case "mouth":{
            Feature feature = featureFactory.GetFeature("mouth");
            temp_dict.Add("mouth",final_output1["mouth"]);
            switch(b){
              case "A":{final_output1.Remove("mouth");
                final_output1.Add("mouth",feature.printFeatureA());
                Console.WriteLine("Mouth to style A");
                originator.setState("Mouth to style A");
                caretaker.add(originator.saveStateToMemento());
                break;}
              case "B":{final_output1.Remove("mouth");
                final_output1.Add("mouth",feature.printFeatureB());
                Console.WriteLine("Mouth to style B");
                originator.setState("Mouth to style B");
                caretaker.add(originator.saveStateToMemento());break;}
              case "C":{final_output1.Remove("mouth");
                final_output1.Add("mouth",feature.printFeatureC());
                Console.WriteLine("Mouth to style C");
                originator.setState("Mouth to style C");
                caretaker.add(originator.saveStateToMemento());break;}
              default: Console.WriteLine("Please enter a valid style");break;
            }
            break;
          }
          default: Console.WriteLine("Please enter a valid feature");break;
        }
       }
       else
           Console.WriteLine("Cannot add Styles as feature is not added"); 
      }
      

      //move
      void Move_feature(string a, string b, int c){
        if(final_output1.ContainsKey(a)){
            switch(a){
                case "left-eye":{temp_dict.Add("left-eye",final_output1["left-eye"]);
                Feature feature = featureFactory.GetFeature("left-eye");
                  switch(b){
                    case "up":{final_output1.Remove("left-eye");leftEye.CY -= c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved up " + c+"px");
                    originator.setState("Left-Eye moved up " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "down":{final_output1.Remove("left-eye");leftEye.CY += c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved down " + c+"px");
                    originator.setState("Left-Eye moved down " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "left":{final_output1.Remove("left-eye");leftEye.CX -= c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved left " + c+"px");
                    originator.setState("Left-Eye moved left " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "right":{final_output1.Remove("left-eye");leftEye.CY += c;
                    final_output1.Add("left-eye",feature.printFeatureA());
                    Console.WriteLine("Left-Eye moved right " + c+"px");
                    originator.setState("Left-Eye moved right " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                case "right-eye":{temp_dict.Add("right-eye",final_output1["right-eye"]);
                Feature feature = featureFactory.GetFeature("right-eye");
                  switch(b){
                    case "up":{final_output1.Remove("right-eye");leftEye.CY -= c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved up " + c+"px");
                    originator.setState("Right-Eye moved up " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "down":{final_output1.Remove("right-eye");leftEye.CY += c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved down " + c+"px");
                    originator.setState("Left-Eye moved down " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "left":{final_output1.Remove("right-eye");leftEye.CX -= c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved left " + c+"px");
                    originator.setState("Right-Eye moved left " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "right":{final_output1.Remove("right-eye");leftEye.CY += c;
                    final_output1.Add("right-eye",feature.printFeatureA());
                    Console.WriteLine("Right-Eye moved right " + c+"px");
                    originator.setState("Right-Eye moved right " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                case "right-brow":{temp_dict.Add("right-brow",final_output1["right-brow"]);
                Feature feature = featureFactory.GetFeature("right-brow");
                  switch(b){
                    case "up":{final_output1.Remove("right-brow");leftEye.CY -= c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved up " + c+"px");
                    originator.setState("Right-Brow moved up " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "down":{final_output1.Remove("right-brow");leftEye.CY += c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved down " + c+"px");
                    originator.setState("Right-Brow moved down " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "left":{final_output1.Remove("right-brow");leftEye.CX -= c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved left " + c+"px");
                    originator.setState("Right-Brow moved left " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "right":{final_output1.Remove("right-brow");leftEye.CY += c;
                    final_output1.Add("right-brow",feature.printFeatureA());
                    Console.WriteLine("Right-Brow moved right " + c+"px");
                    originator.setState("Right-Brow moved right " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                case "left-brow":{temp_dict.Add("left-brow",final_output1["left-brow"]);
                Feature feature = featureFactory.GetFeature("left-brow");
                  switch(b){
                    case "up":{final_output1.Remove("left-brow");leftEye.CY -= c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved up " + c+"px");
                    originator.setState("Left-Brow moved up " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "down":{final_output1.Remove("left-brow");leftEye.CY += c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved down " + c+"px");
                    originator.setState("Left-Brow moved down " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "left":{final_output1.Remove("left-brow");leftEye.CX -= c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved left " + c+"px");
                    originator.setState("Left-Brow moved left " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    case "right":{final_output1.Remove("left-eye");leftEye.CY += c;
                    final_output1.Add("left-brow",feature.printFeatureA());
                    Console.WriteLine("Left-Brow moved right " + c+"px");
                    originator.setState("Left-Brow moved right " + c+"px");
                    caretaker.add(originator.saveStateToMemento());break;}
                    default: Console.WriteLine("Please enter a valid direction");break;
                  }break;
                }
                default: Console.WriteLine("Please enter a valid feature");break;
              }
              }
              else
                Console.WriteLine("Cannot move as feature is not added");
      }


      //rotate
      void Rotate_feature(string a, string b, int c){
        if(final_output1.ContainsKey(a)){
          switch(a){
            case "left-eye":{Feature feature = featureFactory.GetFeature("left-eye");
              temp_dict.Add("left-eye",final_output1["left-eye"]);
              final_output1.Remove("left-eye");
              switch(b){
                case "clockwise":{
                  final_output1.Add("left-eye",feature.rotateFeature(c));
                  Console.WriteLine("Left-Eye rotated "+ c + "degrees clockwise");
                  originator.setState("Left-Eye rotated "+ c + "degrees clockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                case "anticlockwise":{
                  final_output1.Add("left-eye",feature.rotateFeature(-c));
                  Console.WriteLine("Left-Eye rotated "+ c + "degrees anticlockwise");
                  originator.setState("Left-Eye rotated "+ c + "degrees anticlockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "right-eye":{Feature feature = featureFactory.GetFeature("right-eye");
              temp_dict.Add("right-eye",final_output1["right-eye"]);
              final_output1.Remove("right-eye");
              switch(b){
                case "clockwise":{
                  final_output1.Add("right-eye",feature.rotateFeature(c));
                  Console.WriteLine("Right-Eye rotated "+ c + "degrees clockwise");
                  originator.setState("Right-Eye rotated "+ c + "degrees clockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                case "anticlockwise":{
                  final_output1.Add("right-eye",feature.rotateFeature(-c));
                  Console.WriteLine("Right-Eye rotated "+ c + "degrees clockwise");
                  originator.setState("Right-Eye rotated "+ c + "degrees anticlockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "left-brow":{Feature feature = featureFactory.GetFeature("left-brow");
              temp_dict.Add("left-brow",final_output1["left-brow"]);
              final_output1.Remove("left-brow");
              switch(b){
                case "clockwise":{
                  final_output1.Add("left-brow",feature.rotateFeature(c));
                  Console.WriteLine("Left-Brow rotated "+ c + "degrees clockwise");
                  originator.setState("Left-Brow rotated "+ c + "degrees clockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                case "anticlockwise":{
                  final_output1.Add("left-brow",feature.rotateFeature(-c));
                  Console.WriteLine("Left-Brow rotated "+ c + "degrees anticlockwise");
                  originator.setState("Left-Brow rotated "+ c + "degrees anticlockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "right-brow":{Feature feature = featureFactory.GetFeature("right-brow");
              temp_dict.Add("right-brow",final_output1["right-brow"]);
              final_output1.Remove("right-brow");
              switch(b){
                case "clockwise":{
                  final_output1.Add("right-brow",feature.rotateFeature(c));
                  Console.WriteLine("Right-brow rotated "+ c + "degrees clockwise");
                  originator.setState("right-brow rotated "+ c + "degrees clockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                case "anticlockwise":{
                  final_output1.Add("right-brow",feature.rotateFeature(-c));
                  Console.WriteLine("Right-brow rotated "+ c + "degrees anticlockwise");
                  originator.setState("right-brow rotated "+ c + "degrees anticlockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            case "mouth":{Feature feature = featureFactory.GetFeature("mouth");
              temp_dict.Add("mouth",final_output1["mouth"]);
              final_output1.Remove("mouth");
              switch(b){
                case "clockwise":{
                  final_output1.Add("mouth",feature.rotateFeature(c));
                  Console.WriteLine("mouth rotated "+ c + "degrees clockwise");
                  originator.setState("mouth rotated "+ c + "degrees clockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                case "anticlockwise":{
                  final_output1.Add("mouth",feature.rotateFeature(-c));
                  Console.WriteLine("mouth rotated "+ c + "degrees anticlockwise");
                  originator.setState("mouth rotated "+ c + "degrees clockwise");
                  caretaker.add(originator.saveStateToMemento());break;
                }
                default: Console.WriteLine("Please enter a valid direction");break;
              }
              break;
            }
            default: Console.WriteLine("Please enter a valid feature");break;
          }
        }
        else
           Console.WriteLine("Cannot rotate as feature is not added");
      }


      //undo
      void Undo_feature(Caretaker caretaker,Originator originator){
        string feature = originator.getState().Split(" ")[0].ToLower();
        switch(feature){
          case "left-eye":{Console.WriteLine("Undo Successful");break;}
          case "right-eye":{Console.WriteLine("Undo Successful");break;}
          case "left-brow":{Console.WriteLine("Undo Successful");break;}
          case "right-brow":{Console.WriteLine("Undo Successful");break;}
          case "mouth":{Console.WriteLine("Undo Successful");break;}
        }
        caretaker.del(); //removes the current feature from the undo list and adds it to the redo list
           originator.getStateFromMemento(caretaker.get(caretaker.count_list()));
           /*now getting the current state which is the shape which was added previously to the one we
            removed right now.*/
      }

     //redo
     void Redo_feature(Caretaker caretaker,Originator originator){
      if(caretaker.redo_count_list() == 0){
        Console.WriteLine("Cannot Redo!");
        return;
      }
      else{
        caretaker.re();//removes the last feature in the redo list and adds it to the undo list
              originator.getStateFromMemento(caretaker.get(caretaker.count_list()));
              //now we get the current state which is the shape we added just now in the undo list
              string feature = originator.getState().Split(" ")[0].ToLower();
        switch(feature){
          case "left-eye":{Console.WriteLine("Redo Successful");break;}
          case "right-eye":{Console.WriteLine("Redo Successful");break;}
          case "left-brow":{Console.WriteLine("Redo Successful");break;}
          case "right-brow":{Console.WriteLine("Redo Successful");break;}
          case "mouth":{Console.WriteLine("Redo Successful");break;}
        }
      }
     }

      //displays the features added so far
      void Draw_feature(){
        Console.WriteLine(svg_header);
        for(int i= final_output1!.Count-1; i >= 0; i--){
          Console.WriteLine(final_output1.ElementAt(i).Value);//printing the shapes on the terminal
        }
        Console.WriteLine("</svg>");
      }
      
      //printing on the command line after the user quits the application
      Console.WriteLine(svg_header);
      for(int i= final_output1!.Count-1; i >= 0; i--){
          svg_text.Append(final_output1.ElementAt(i).Value);
          //printing the shapes on the terminal
          Console.WriteLine(final_output1.ElementAt(i).Value);
        }
        Console.WriteLine("</svg>");

      svg_text.Append("</svg>");
      System.IO.File.WriteAllText(output_file!, svg_text.ToString());
    
    }
  }
}