import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Import components to be routed
import { CategoryManagementComponent } from './components/category-management/category-management.component';
import { ProductManagementComponent } from './components/product-management/product-management.component';

// Define routes
const routes: Routes = [
  { path: 'products', component: ProductManagementComponent},
  { path: 'categories', component: CategoryManagementComponent},
  { path: '', redirectTo: '/products', pathMatch: 'full' }, // Default route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
