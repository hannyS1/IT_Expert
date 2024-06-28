import React, { useState } from 'react';

import './ItemInput.css';
import {overwriteData} from "../../services/ItemService";

export default function ItemInput() {
    const [items, setItems] = useState([{ code: '', value: '' }]);

    const handleChangeItem = (index, key, value) => {
        let newItems = [...items];
        newItems[index][key] = value;
        setItems(newItems);
    };

    const handleAddItem = () => {
        setItems([...items, { code: '', value: '' }]);
    };

    const handleRemoveItem = (index) => {
        let newItems = items.filter((_, i) => i !== index);
        setItems(newItems);
    };

    const handleSubmit = () => {
        let jsonData = items.map(({ code, value }) => ({ [code]: value }));
        console.log(jsonData);

        overwriteData(jsonData)

        setItems([{ code: '', value: '' }]);
    };

    return (
        <div>
            <div className="form-container" id="input-container">
                {items.map((item, index) => (
                    <div className="form-group">
                        <label htmlFor="code">Code</label>
                        <input
                            type="text"
                            id="code"
                            name="code"
                            value={item.code}
                            onChange={(e) => handleChangeItem(index, 'code', e.target.value)} />
                        <label htmlFor="value">Value</label>
                        <input
                            type="text"
                            id="value"
                            name="value"
                            value={item.value}
                            onChange={(e) => handleChangeItem(index, 'value', e.target.value)} />
                        <button type="button" className="remove-button" onClick={() => handleRemoveItem(index)}>
                            Удалить
                        </button>
                    </div>
                ))}
                <div className="form-group">
                    <button className="add-button" type="button" onClick={handleAddItem}>Добавить запись</button>
                    <button className="submit-button" type="button" onClick={handleSubmit}>Сохранить</button>
                </div>
            </div>
        </div>
    );
};