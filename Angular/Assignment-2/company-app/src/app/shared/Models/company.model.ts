import { Companybranch } from './companybranch.model';

export class Company {
  id: number;
  email: string;
  name: string;
  totalEmployee: number;
  address: string;
  isCompanyActive: boolean;
  totalBranch: number;
  companyBranch: Companybranch[];
}
