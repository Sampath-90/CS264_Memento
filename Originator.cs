public class Originator{
    private string ?state;
    public void setState(string state){this.state = state;} //sets the state
    public string getState(){return state!;} //get the requested state
    public Memento saveStateToMemento(){return new Memento(state!);} //saves the current state to a memento
    public string getStateFromMemento(Memento memento){state = memento.getState();return state;}
    //gets the required state from a memento
    
}