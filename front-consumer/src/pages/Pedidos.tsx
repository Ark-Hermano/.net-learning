import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Pedido, getPedidos, deletePedido } from '../api';

export function Pedidos() {
  const [pedidos, setPedidos] = useState<Pedido[]>([]);

  useEffect(() => {
    async function fetchPedidos() {
      const pedidos = await getPedidos();
      setPedidos(pedidos);
    }
    fetchPedidos();
  }, []);

  async function handleDeletePedido(id: number) {
    await deletePedido(id);
    setPedidos(pedidos.filter((pedido) => pedido.id !== id));
  }

  return (
    <div>
      <h1>Pedidos</h1>
      <Link to="/pedidos/novo">Novo Pedido</Link>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Produto ID</th>
            <th>User ID</th>
            <th>Data de Criação</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {pedidos.map((pedido) => (
            <tr key={pedido.id}>
              <td>{pedido.id}</td>
              <td>{pedido.produtoId}</td>
              <td>{pedido.userId}</td>
              <td>{new Date(pedido.dataCriacao).toLocaleString()}</td>
              <td>
                <Link to={`/pedidos/${pedido.id}`}>Editar</Link>
                <button onClick={() => handleDeletePedido(pedido.id)}>Excluir</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
