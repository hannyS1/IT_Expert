import './ItemList.css'
import {useState} from "react";
import {getItems} from "../../services/ItemService";

export default function ItemList() {
    const [items, setItems] = useState([]);
    const [filter, setFilter] = useState({code: '', value: ''});

    const changeFilterHandle = (key, value) => {
        setFilter(prevFilter => ({
            ...prevFilter,
            [key]: value
        }));
    }

    const fetchItemsHandle = async (filter) => {
        let items = await getItems(filter);
        setItems(items);
    }

    return(
        <div>
            <div className="filter-container">
                <div className="filter-group">
                    <label htmlFor="codeFilter">Code</label>
                    <input
                        type="text"
                        id="codeFilter"
                        value={filter.code}
                        onChange={(e) => changeFilterHandle('code', e.target.value)}
                    />
                    <label htmlFor="valueFilter">Value</label>
                    <input
                        type="text"
                        id="valueFilter"
                        value={filter.value}
                        onChange={(e) => changeFilterHandle('value', e.target.value)}
                    />
                    <button
                        onClick={() => fetchItemsHandle(filter)}
                    >
                        Получить объекты
                    </button>
                </div>
            </div>
            <div className="list-container">
                <div className="list-header">
                    <div>ID</div>
                    <div>Code</div>
                    <div>Value</div>
                </div>
                <div id="listContainer">
                    {items.map((item) => (
                        <div className="list-item">
                            <div>{item.id}</div>
                            <div>{item.code}</div>
                            <div>{item.value}</div>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    )
}