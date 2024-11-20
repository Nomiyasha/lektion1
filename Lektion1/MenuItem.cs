using System.Collections;

namespace Lektion1;

public abstract class MenuItem
{
    private readonly string label;
    private readonly ConsoleKey key;
    
    public MenuItem(ConsoleKey key, string label){
        this.key = key;
        this.label = label;
    }
    public string[] Print(){

        string keyprint = key switch{
            ConsoleKey.UpArrow => "Up",
            ConsoleKey.DownArrow => "Down",
            ConsoleKey.RightArrow => "Right",
            ConsoleKey.LeftArrow => "Left",
            _ => key.ToString()
        };
        keyprint = " <" + keyprint + "> ";
        if(keyprint.Length < 8)
        {
            for(int i = 0; i < 8-keyprint.Length; i++){
                keyprint = " " + keyprint + " ";
            }
        }

        string labelprint = " " + label + " ";
        if(labelprint.Length < keyprint.Length)
        {
            for(int i = 0; i < keyprint.Length-labelprint.Length; i++){
                labelprint = " " + labelprint + " ";
            }
        }

        return [$"{keyprint}", $"{labelprint}"];
    }

    protected abstract void Execute(ShapeLayer layer);
    public void Handle(ConsoleKey key, ShapeLayer layer){
        if(this.key == key){
            Execute(layer);
        }
    }
}