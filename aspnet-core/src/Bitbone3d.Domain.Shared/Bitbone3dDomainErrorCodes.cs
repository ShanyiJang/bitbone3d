namespace Bitbone3d;

public static class Bitbone3dDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public static class BasicData
    {
        public const string ConsultingRoomCodeDuplicated = "Bitbone3d.BasicData.ConsultingRoom:0001";
        public const string ConsultingRoomNameDuplicated = "Bitbone3d:BasicData.ConsultingRoom:0002";
        public const string DepartmentCodeDuplicated = "Bitbone3d.BasicData.Department:0001";
        public const string DepartmentNameDuplicated = "Bitbone3d.BasicData.Department:0002";
        public const string RegTitleCodeDuplicated = "Bitbone3d.BasicData.RegTitle:0001";
        public const string RegTitleNameDuplicated = "Bitbone3d.BasicData.RegTitle:0002";
    }

    public static class DoctorDeptPermission
    {
    }

    public static class Doctors
    {
        public const string DoctorUserNameDuplicated = "Bitbone3d.Doctors:0001";
    }

    public static class Scheduling
    {
        public const string SchedulingShiftCodeDuplicated = "Bitbone3d.Scheduling.SchedulingShift:0001";
        public const string SchedulingShiftNameDuplicated = "Bitbone3d.Scheduling.SchedulingShift:0002";
        public const string SchedulingShiftStartTimeGreaterThanEndTime = "Bitbone3d.Scheduling.SchedulingShift:0003";

        public static class SchedulingRequests
        {
            public const string DoctorNotHasRegTitle = "Bitbone3d.Scheduling.SchedulingRequests.:0001";
            public const string DoctorNotHasDepartmentPermission = "Bitbone3d.Scheduling.SchedulingRequests.:0002";

            public const string DoctorNotHasDepartmentSchedulingPermission
                = "Bitbone3d.Scheduling.SchedulingRequests.:0003";

            public const string ConsultingRoomNotBelongToDepartment = "Bitbone3d.Scheduling.SchedulingRequests.:0004";
            public const string EndTimeTooClose = "Bitbone3d.Scheduling.SchedulingRequests.:0005";
        }
    }
    
    public static class DddParking
    {
        public const string FeeUnpaid = "Bitbone3d.DddParking:0001";
        public const string VehicleNotEntered = "Bitbone3d.DddParking:0002";
    }
}