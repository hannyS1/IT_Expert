import './App.css';
import ItemInput from "./components/itemInput/ItemInput";
import ItemList from "./components/ItemLIst/ItemList";

function App() {
  return (
      <div className="App">
          <div className="centered-box">
              <span><h2>Перезапись объектов</h2></span>
              <ItemInput/>
              <span><h2>Получение объектов</h2></span>
              <ItemList/>
          </div>
      </div>
  );
}

export default App;
