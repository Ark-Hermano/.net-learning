import axios from 'axios';

export interface Pedido {
  id: number;
  produtoId: string;
  userId: string;
  dataCriacao: string;
}

export async function getPedidos(): Promise<Pedido[]> {
  const response = await axios.get<Pedido[]>('http://localhost:7249/api/pedidos');
  return response.data;
}

export async function addPedido(pedido: Omit<Pedido, 'id'>): Promise<Pedido> {
  const response = await axios.post<Pedido>('http://localhost:7249/api/pedidos', pedido);
  return response.data;
}

export async function updatePedido(pedido: Pedido): Promise<Pedido> {
  const response = await axios.put<Pedido>(`http://localhost:7249/api/pedidos/${pedido.id}`, pedido);
  return response.data;
}

export async function deletePedido(id: number): Promise<void> {
  await axios.delete(`http://localhost:7249/api/pedidos/${id}`);
}
