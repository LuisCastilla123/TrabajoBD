export interface OptionDTO {
  id: string;
  name: string;
}

export interface UserInfoResponse {
  location?: string;
  about?: string;
  skills?: OptionDTO[];
  languages?: OptionDTO[];
}

export interface AcademicHistoryResponse {
  academicHistoryId: string;
  institutionName: string;
  speciality: string;
  degree?: OptionDTO;
  academicField?: OptionDTO;
  startDate: Date;
  endDate?: Date;
}

export interface WorkExperienceResponse {
  workExperienceId: string;
  enterpriseName: string;
  startDate: Date;
  endDate?: Date;
  jobTitle?: OptionDTO;
  description?: string;
}

export interface UserResponse {
  userId: string;
  userName: string;
  email: string;
  phoneNumber?: string;
  userInfo?: UserInfoResponse;
  academicHistories: AcademicHistoryResponse[];
  workExperiences: WorkExperienceResponse[];
}

export interface CVResponse {
  user: UserResponse;
  updatedAt: Date;
}

export interface OptionsResponse {
  academicFields: OptionDTO[];
  degrees: OptionDTO[];
  jobtitles: OptionDTO[];
  languages: OptionDTO[];
  skills: OptionDTO[];
}

export interface WorkExperienceRequest {
  enterpriseName: string;
  startDate: string;
  endDate: string;
  description: string;
  jobTitleId: string;
}
