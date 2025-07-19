import { useEffect, useState } from "react";
import { getPopularSuppliers } from "../shared/api2";
import type { MostPopularSuppliersResponse } from "../shared/Api";

// Блок со списком популярных поставщиков. Вывести троих поставщиков (наименование и количеством офферов у каждого) с наибольшим количеством офферов.
export const MostPopularSuppliers = () => {
    const [popularSuppliers, setPopularSuppliers] = useState<MostPopularSuppliersResponse[]>([]);

    useEffect(()=>{
        const fetchSuppliers = async () => {
            const data: MostPopularSuppliersResponse[] = await getPopularSuppliers();
            setPopularSuppliers(data);
        };
        fetchSuppliers();
    },[]);

    return (
        <div>
            <h3>Популярные Поставщики</h3>
            {popularSuppliers.map(supplier => (
                <div>
                    <span>{supplier.name} - Количество офферов: {supplier.count}</span>
                </div>
            ))}
        </div>
    );
};