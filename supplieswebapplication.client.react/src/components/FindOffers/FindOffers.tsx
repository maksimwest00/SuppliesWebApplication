// 2) Блок со строкой поиска. Строка поиска должна искать по полям: Марка, Модель, Поставщик

import { useEffect, useState } from "react";
import './FindOffers.css';
import type { Offer } from "../../shared/Api";
import { findOffers } from "../../shared/api2";

export const FindOffers = () => {
    const [stamp, setStamp] = useState<string>();
    const [model, setModel] = useState<string>();
    const [supplierId, setSupplierId] = useState<string>();

    const [offers, setOffers] = useState<Offer[]>([]);

    const fetchOffers: (query?: {
        Stamp?: string;
        Model?: string;
        SupplierId?: string;
      }) => Promise<void> = async (query) => {
        const data: Offer[] = await findOffers(query);
        setOffers(data);
    };

    useEffect(()=>{
        fetchOffers();
    },[]);

    function Search(query?: {
        Stamp?: string;
        Model?: string;
        SupplierId?: string;
      }) {
        fetchOffers({Stamp: stamp, Model: model, SupplierId: supplierId});
    };

    return (
        <div className="mainBox">
            <div className='childBox'>
                <span>Марка</span>
                <input value={stamp} onChange={(e: React.ChangeEvent<HTMLInputElement>) => { setStamp(e.target.value) }} />
                <span>Модель</span>
                <input value={model} onChange={(e: React.ChangeEvent<HTMLInputElement>) => { setModel(e.target.value) }} />
                <span>Id поставщика</span>
                <input value={supplierId} onChange={(e: React.ChangeEvent<HTMLInputElement>) => { setSupplierId(e.target.value) }} />
                <button onClick={() => Search()}>
                    Поиск
                </button>
            </div>
            <div className='childBox'>
                <h3>Офферы, Офферов всего: {offers?.length}</h3>
                {offers.map(offer => (
                    <div className="mainBox">
                        <span>{offer.stamp} {offer.model}</span>
                    </div>
                ))}
            </div>
        </div>
    );
};