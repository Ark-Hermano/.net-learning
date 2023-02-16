import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from 'react-router-dom'
import App from './App'
import './index.css'
import EditarPedido from './pages/EditarPedido'

import { Pedidos } from './pages/Pedidos'
import { NovoPedido } from './pages/NovoPedido'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route path="/" element={<Pedidos />} />
      <Route path="/pedidos/novo" element={<NovoPedido />} />
      <Route path="/pedidos/editar" element={<EditarPedido />} />
    </>

  ))

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
