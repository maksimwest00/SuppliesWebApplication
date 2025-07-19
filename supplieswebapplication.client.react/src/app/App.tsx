import { FindOffers } from '../components/FindOffers/FindOffers';
import { MostPopularSuppliers } from '../components/MostPopularSuppliers';
import './App.css';

const MostPopularBoxComponent = () => {
    return (
        <div className="centered-content">
              <MostPopularSuppliers/>
          </div>
    );
};

const FindOffersBoxComponent = () => {
    return (
        <FindOffers />
    );
};

export const App = () => {
  return (
      <div className='centered-container'>
          <MostPopularBoxComponent/>
          <FindOffersBoxComponent/>
      </div>
  )
};