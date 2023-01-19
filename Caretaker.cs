public class Caretaker{
     private List<Memento> Undo = new List<Memento>();
     private List<Memento> Redo = new List<Memento>();
    public void add(Memento state){
        if(Undo.Count == 0 && Redo.Count != 0){
            /*if a user uses undo to remove all the features created so far and then tries to add a 
            new one which isn't the one the user created earlier. Then the redo list should be cleared*/
            Redo.Clear();
            Undo.Add(state);
        }
        else
            Undo.Add(state); //adds the current feature created to the undo list.
    }
    public void del(){  //undo
        if(Undo.Count == 0){
            //if there isn't anything on the undo list and the user tries to press undo
            Console.WriteLine("Cannot Undo!");
            return;
        }
        Redo.Add(Undo.Last()); //adds the last feature from undo list to the redo list
        Undo.Remove(Undo.Last()); //removing the last feature created from the list as we added on the redo list
    }
    public void re(){  //redo
        Undo.Add(Redo.Last()); //adds the last feature on the redo list to the undo list
        Redo.Remove(Redo.Last()); //removing the last feature on the list as we added it back on the undo list
    }
    public Memento get(int index){
        if(index >= 0 && Undo.Count > index){
            return Undo.ElementAt(index);  //gets the requested feature which is on the undo list
        }
        else{
            return new Memento("");
        }
    }
    public int count_list(){
        return Undo.Count()-1;
    }
    public int redo_count_list(){
        return Redo.Count();
    }
    
}
