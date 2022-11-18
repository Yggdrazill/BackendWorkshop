import React, { useState } from 'react';

import './Item.css';

import NewItemPNG from './newitem.png';
import IconBitcoin from './bitcoin.png';
import IconRtx from './rtx.png';
import IconRc from './revell.jpeg';
import IconAoE4 from './aoe4.png';
import IconStiga from './stiga.jpeg';


export default function Item(props) {

	const [newCost, setNewCost] = useState(0);

	let val = <>{props.cost}kr</>;
	
	if (props.sale) {
		val = <><span style={{ textDecoration: 'line-through' }}>{val}</span><span style={{ color: 'red' }}> {props.sale}kr</span></>;
	}
	let className = "";
	if (props.funStuff) {
		className = "FunStuff";
	}
	console.log(newCost);
	
	return (
		<div className="Item">
			<div className={className}>
				<img alt={props.name} src={IdToIcon(props.imageId)}/>
			</div>
			<p>
				<b>
					{props.name}
				</b>
			</p>
			<p>
				{val}
			</p>
			{ props.onBuy != null && <input value="Köp" type="button" onClick={() => props.onBuy(props.name, props.sale ?? props.cost)} /> }
			{ props.onEdit != null && (
				<div>
					Nytt pris
					<input className={"NewPriceInput"} id={newCost} value={newCost} min="0" type="number" onChange={(input) => setNewCost(input.target.value)} /> 
				</div>
			)}
			{ props.onEdit != null && <input value="Ändra" type="button" onClick={() => props.onEdit(props.id, newCost)} /> }
		</div>
	);
}

export function NewItem(props) {
	

	const [cost, setCost] = useState(0);
	const [name, setName] = useState('');
	const [imageId] = useState(0);


	return (
		<div className="Item">
			<img alt='' src={IdToIcon(imageId)}/>
			<p>
				<b>
					Välj namn
				</b>
				<input className={"NewPriceInput"} value={name} type="string" onChange={(input) => setName(input.target.value)} />
			</p>
			<p>
				<b>
					Välj pris
				</b>
				<input className={"NewPriceInput"} value={cost} min="0" type="number" onChange={(input) => setCost(input.target.value)} />
			</p>
			<input value="Spara" type="button" onClick={() => props.onCreate(name, cost, imageId)} />
		</div>
	);
}

function IdToIcon(id) {
	switch (id) {
		case 0:
			return NewItemPNG;
		case 1:
			return IconAoE4;
		case 2:
			return IconStiga;
		case 3:
			return IconBitcoin;
		case 4:
			return IconRtx;
		case 5:
			return IconRc;
		default:
			return null;
	

	}

}