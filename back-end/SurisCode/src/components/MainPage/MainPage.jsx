import Articulos from "../Articulos/Articulos";
import Header from "../Header/Header";
import Vendedores from "../Vendedores/Vendedores";

export default function MainPage() {
  return (
    <div>
      <Header />
      <div className="container d-flex justify-content-center align-center">
        <div className="row">
          <Articulos />
          <Vendedores />
        </div>
      </div>
    </div>
  );
}
