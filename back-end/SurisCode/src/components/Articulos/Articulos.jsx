import { useState, useEffect } from "react";
import { Button } from "react-bootstrap";

export default function Articulos() {
  const [articulos, setArticulos] = useState([]);
  const [articulosSeleccionados, setArticulosSeleccionados] = useState([]);

  const leerArticulos = async () => {
    try {
      const response = await fetch("https://localhost:7218/api/articulo/articulos");
      const data = await response.json();
      setArticulos(data);
    } catch (error) {
      console.log("error al cargar los articulos:", error);
    }
  };

  useEffect(() => {
    leerArticulos();
  }, []);
  const handleSeleccionArticulo = (code) => {
    setArticulosSeleccionados((prev) => [...prev, code]);
  };
  const handleCrearPedido = async () => {
    try {
      if (!articulosSeleccionados || articulosSeleccionados.length === 0) {
        alert('Selecciona un elemento por favor');
        return;
    }
      const response = await fetch("https://localhost:7218/api/pedido/crearpedido", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ articulosCodigo: articulosSeleccionados }),
      });
     
      console.log(articulosSeleccionados);
      
      if (response.ok) {
        setArticulosSeleccionados([]);
       } else {
        setMensaje("error al realizar el pedido");
      }
    } catch (error) {
      console.error("error al realizar el pedido:", error);
    }
  };
  //
  return (
    <div class="card text-dark bg-light mb-4 ">
      <div class="card-body">
        <h1 className="card-title text-center">Articulos</h1>
        <table className="table">
          <thead className="thead-dark">
            <tr>
              <th className="text-center">Seleccionar Compra</th>
              <th>Nombre articulo</th>
              <th>Precio</th>
            </tr>
          </thead>
          <tbody>
            {articulos.map((articulo, index) => (
              <tr key={index}>
                <td className="text-center form-control-lg">
                  <label className="justify-content-center">
                    <input
                      type="checkbox"
                      checked={articulosSeleccionados.includes(articulo.codigo)}
                      onChange={() => handleSeleccionArticulo(articulo.codigo)}
                    />
                  </label>
                </td>
                <td>{articulo.descripcion}</td>
                <td>${articulo.precio}</td>
              </tr>
            ))}
          </tbody>
        </table>
            <div className="container d-flex justify-content-center align-center">
              <Button onClick={handleCrearPedido}>Enviar Pedido</Button>
            </div>
      </div>
    </div>
  );
}
